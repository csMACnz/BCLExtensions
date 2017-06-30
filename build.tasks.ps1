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
    $script:coveralls = "csmacnz.Coveralls.exe"

}

task default

task RestoreNuGetPackages {
    exec { dotnet restore $sln_file }
}

task GitVersion {
    GitVersion /output buildserver /updateassemblyinfo
}

task LocalTestSettings {
}

task ResolveCoverallsPath {
    $script:coveralls = (Resolve-Path "src/packages/coveralls.net.*/tools/csmacnz.coveralls.exe").ToString()
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
    dotnet clean $sln_file
}

task build {
    exec { dotnet build $sln_file }
}

task setup-coverity-local {
  $env:APPVEYOR_BUILD_FOLDER = "."
  $env:APPVEYOR_BUILD_VERSION = $script:version
  $env:APPVEYOR_REPO_NAME = "csmacnz/BCLExtensions"
  "You should have set the COVERITY_TOKEN and COVERITY_EMAILenvironment variable already"
  $env:APPVEYOR_SCHEDULED_BUILD = "True"
}

task test-coverity -depends setup-coverity-local, coverity

task coverity -precondition { return $env:APPVEYOR_SCHEDULED_BUILD -eq "True" }{
  $coverityFileName = "BCLExtensions.coverity.$script:nugetVersion.zip"
  $PublishCoverity = (Resolve-Path ".\src\packages\PublishCoverity.*\tools\PublishCoverity.exe").ToString()

  & cov-build --dir cov-int msbuild "/t:Clean;Build" "/p:Configuration=$configuration" $sln_file

  & $PublishCoverity compress -o $coverityFileName

  & $PublishCoverity publish -t $env:COVERITY_TOKEN -e $env:COVERITY_EMAIL -z $coverityFileName -d "AppVeyor scheduled build ($env:APPVEYOR_BUILD_VERSION)." --codeVersion $script:nugetVersion
}

task coverage -depends LocalTestSettings, build, coverage-only

task coverage-only {
    $opencover = (Resolve-Path ".\src\packages\OpenCover.*\tools\OpenCover.Console.exe").ToString()
    exec { & $opencover -register:user -target:$script:xunit "-targetargs:""src\BCLExtensions.Tests\bin\$Configuration\BCLExtensions.Tests.dll"" -noshadow $script:testOptions" -filter:"+[BCLExtensions*]*" -output:BCLExtensionsCoverage.xml }
}

task test-coveralls -depends coverage, ResolveCoverallsPath {
    exec { & $coveralls --opencover -i BCLExtensionsCoverage.xml --dryrun -o coverallsTestOutput.json --repoToken "NOTAREALTOKEN" }
}

task coveralls -depends ResolveCoverallsPath -precondition { return -not $env:APPVEYOR_PULL_REQUEST_NUMBER }{
    exec { & $coveralls --opencover -i BCLExtensionsCoverage.xml --treatUploadErrorsAsWarnings }
}

task codecov {
    (New-Object System.Net.WebClient).DownloadFile("https://codecov.io/bash", ".\CodecovUploader.sh")
    .\CodecovUploader.sh -t $env:CODECOV_TOKEN -f BCLExtensionsCoverage.xml
}

task archive -depends build, archive-only

task archive-only {
    $archive_filename = "BCLExtensions.$script:nugetVersion.zip"

    mkdir $archive_dir

    cp "$build_output_dir\BCLExtensions.dll" "$archive_dir"

    Add-Type -assembly "system.io.compression.filesystem"

    [io.compression.zipfile]::CreateFromDirectory("$archive_dir", $archive_filename)
}

task pack -depends build, pack-only

task pack-only {

    mkdir $nuget_pack_dir

    dotnet pack ".\src\BCLExtensions\BCLExtensions.csproj" --output $nuget_pack_dir
}

task postbuild -depends pack, archive, coverage-only, codecov, coveralls

task appveyor-install -depends GitVersion, RestoreNuGetPackages

task appveyor-build -depends build

task appveyor-test -depends AppVeyorEnvironmentSettings, postbuild, coverity
