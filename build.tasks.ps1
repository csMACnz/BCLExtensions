properties {
    # build variables
    $framework = "4.5.1"		# .net framework version
    $configuration = "Release"	# build configuration
    $script:version = "1.0.0"
    $script:nugetVersion = "1.0.0"
    $script:runCoverity = $false

    # directories
    $base_dir = . resolve-path .\
    $build_output_dir = "$base_dir\src\BCLExtensions\bin\$configuration\"
    $test_results_dir = "$base_dir\TestResults\"
    $package_dir = "$base_dir\Package\"
    $archive_dir = "$package_dir" + "Archive"
    $nuget_pack_dir = "$package_dir" + "Pack"

    # files
    $sln_file = "$base_dir\src\BCLExtensions.sln"
    $nuspec_filename = "BCLExtensions.nuspec"
    $testOptions = ""
    $script:xunit = "$base_dir\src\packages\xunit.runners.1.9.2\tools\xunit.console.clr4.exe"
    $script:coveralls = "csmacnz.Coveralls.exe"

}

task default

task RestoreNuGetPackages {
    exec { nuget.exe restore $sln_file }
}

task GitVersion {
    GitVersion /output buildserver /updateassemblyinfo true /assemblyVersionFormat Major
}

task LocalTestSettings {
    $script:xunit = "$base_dir/src/packages/xunit.runners.1.9.2/tools/xunit.console.clr4.exe"
    $script:testOptions = ""
}

task ResolveCoverallsPath {
    $script:coveralls = (Resolve-Path "src/packages/coveralls.net.*/csmacnz.coveralls.exe").ToString()
}

task AppVeyorEnvironmentSettings {
    if(Test-Path Env:\GitVersion_ClassicVersion) {
        $script:version = $env:GitVersion_ClassicVersion
        echo "version set to $script:version"
    }
    elseif (Test-Path Env:\APPVEYOR_BUILD_VERSION) {
        $script:version = $env:APPVEYOR_BUILD_VERSION
        echo "version set to $script:version"
    }
    if(Test-Path Env:\GitVersion_NuGetVersionV2) {
        $script:nugetVersion = $env:GitVersion_NuGetVersionV2
        echo "nuget version set to $script:nugetVersion"
    }
    elseif (Test-Path Env:\APPVEYOR_BUILD_VERSION) {
        $script:nugetVersion = $env:APPVEYOR_BUILD_VERSION
        echo "nuget version set to $script:nugetVersion"
    }

    $script:xunit = "xunit.console.clr4.exe"
    $script:testOptions = "/appveyor"
}

task clean {
    if (Test-Path $package_dir) {
      Remove-Item $package_dir -r
    }
    if (Test-Path $test_results_dir) {
      Remove-Item $test_results_dir -r
    }
    $archive_filename = "BCLExtensions.*.zip"
    if (Test-Path $archive_filename) {
      Remove-Item $archive_filename
    }
    $nupkg_filename = "BCLExtensions.*.nupkg"
    if (Test-Path $nupkg_filename) {
      Remove-Item $nupkg_filename
    }
    exec { msbuild "/t:Clean" "/p:Configuration=$configuration" $sln_file }
}

task build {
    exec { msbuild "/t:Clean;Build" "/p:Configuration=$configuration" $sln_file }
}

task appveyor-checkCoverity {
  if($env:APPVEYOR_SCHEDULED_BUILD -eq "True") {
    $script:runCoverity = $true

    #download coverity
    Invoke-WebRequest `
    -Uri "https://scan.coverity.com/download/cxx/win_64" `
    -Body @{ project = "$env:APPVEYOR_REPO_NAME";
             token = "$env:CoverityProjectToken" } `
    -OutFile "$env:APPVEYOR_BUILD_FOLDER\coverity.zip"
    
    # Unzip downloaded package.
    Add-Type -AssemblyName "System.IO.Compression.FileSystem" 
    IO.Compression.ZipFile]::ExtractToDirectory( "$env:APPVEYOR_BUILD_FOLDER\coverity.zip", "$env:APPVEYOR_BUILD_FOLDER")
  }
}

task coverity -precondition { return $script:runCoverity }{
  $covbuild = (Resolve-Path ".\cov-analysis-win64-*\bin\cov-build.exe").ToString();
  & $covbuild --dir cov-int msbuild "/t:Clean;Build" "/p:Configuration=$configuration" $sln_file

  Write-Zip -Path "cov-int" -OutputPath BCLExtensions.coverity.$script:nugetVersion.zip

  #TODO: Upload coverity
}

task coverage -depends LocalTestSettings, build, coverage-only

task coverage-only {
    exec { & .\src\packages\OpenCover.4.5.3522\OpenCover.Console.exe -register:user -target:$script:xunit "-targetargs:""src\BCLExtensions.Tests\bin\$Configuration\BCLExtensions.Tests.dll"" /noshadow $script:testOptions" -filter:"+[BCLExtensions*]*" -output:BCLExtensionsCoverage.xml }
}

task test-coveralls -depends coverage, ResolveCoverallsPath {
    exec { & $coveralls --opencover -i BCLExtensionsCoverage.xml --dryrun -o coverallsTestOutput.json --repoToken "NOTAREALTOKEN" }
}

task coveralls -depends ResolveCoverallsPath {
    exec { & $coveralls --opencover -i BCLExtensionsCoverage.xml --repoToken $env:COVERALLS_REPO_TOKEN --commitId $env:APPVEYOR_REPO_COMMIT --commitBranch $env:APPVEYOR_REPO_BRANCH --commitAuthor $env:APPVEYOR_REPO_COMMIT_AUTHOR --commitEmail $env:APPVEYOR_REPO_COMMIT_AUTHOR_EMAIL --commitMessage $env:APPVEYOR_REPO_COMMIT_MESSAGE --jobId $env:APPVEYOR_JOB_ID }
}

task archive -depends build, archive-only

task archive-only {
    $archive_filename = "BCLExtensions.$script:nugetVersion.zip"

    mkdir $archive_dir

    cp "$build_output_dir\BCLExtensions.dll" "$archive_dir"

    Write-Zip -Path "$archive_dir\*" -OutputPath $archive_filename
}

task pack -depends build, pack-only

task pack-only {

    mkdir $nuget_pack_dir
    cp "$nuspec_filename" "$nuget_pack_dir"

    mkdir "$nuget_pack_dir\lib"
    cp "$build_output_dir\BCLExtensions.dll" "$nuget_pack_dir\lib"

    $Spec = [xml](get-content "$nuget_pack_dir\$nuspec_filename")
    $Spec.package.metadata.version = ([string]$Spec.package.metadata.version).Replace("{Version}", $script:nugetVersion)
    $Spec.Save("$nuget_pack_dir\$nuspec_filename")

    exec { nuget pack "$nuget_pack_dir\$nuspec_filename" }
}

task postbuild -depends pack, archive, coverage-only, coveralls

task appveyor-install -depends GitVersion, RestoreNuGetPackages

task appveyor-build -depends build

task appveyor-test -depends AppVeyorEnvironmentSettings, postbuild, appveyor-checkCoverity, coverity
