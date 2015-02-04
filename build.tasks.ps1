properties {
    # build variables
    $framework = "4.5.1"		# .net framework version
    $configuration = "Release"	# build configuration
    $script:version = "0.1.0"

    # directories
    $base_dir = . resolve-path .\
    $build_output_dir = "$base_dir\src\BCLExtensions\bin\$configuration\"
    $test_results_dir = "$base_dir\TestResults\"

    # files
    $sln_file = "$base_dir\src\BCLExtensions.sln"
    $testOptions = ""
    $script:xunit = "$base_dir\src\packages\xunit.runners.1.9.2\tools\xunit.console.clr4.exe"

}

task default

task RestoreNuGetPackages {
    exec { nuget.exe restore $sln_file }
}

task LocalTestSettings {
    $script:xunit = "$base_dir/src/packages/xunit.runners.1.9.2/tools/xunit.console.clr4.exe"
    $script:testOptions = ""
}

task AppVeyorTestSettings {
    if (Test-Path Env:\APPVEYOR_BUILD_VERSION) {
        $script:version = $env:APPVEYOR_BUILD_VERSION
        echo "version set to $script:version"
    }

    $script:xunit = "xunit.console.clr4.exe"
    $script:testOptions = "/appveyor"
}

task clean {
    if (Test-Path $test_results_dir) {
      Remove-Item $test_results_dir -r
    }

    exec { msbuild "/t:Clean" "/p:Configuration=$configuration" $sln_file }
}

task build {
    exec { msbuild "/t:Clean;Build" "/p:Configuration=$configuration" $sln_file }
}

task coverity {
    cov-build --dir cov-int msbuild "/t:Clean;Build" "/p:Configuration=$configuration" $sln_file

    Write-Zip -Path "cov-int" -OutputPath BCLExtensions.coverity.$script:version.zip
}

task coverage -depends LocalTestSettings, build, coverage-only

task coverage-only {
    exec { & .\src\packages\OpenCover.4.5.3522\OpenCover.Console.exe -register:user -target:$script:xunit "-targetargs:""src\BCLExtensions.Tests\bin\$Configuration\BCLExtensions.Tests.dll"" /noshadow $script:testOptions" -filter:"+[BCLExtensions*]*" -output:BCLExtensionsTests.xml }
}

task coveralls -depends coverage, coveralls-only

task coveralls-only {
    exec { & ".\src\packages\coveralls.net.0.2.95\csmacnz.Coveralls.exe" --opencover -i BCLExtensionsTests.xml --repoToken "JnVjBzTw7uW2AwhUXpeCKUNHj41JbHSGu" --commitId $env:APPVEYOR_REPO_COMMIT --commitBranch $env:APPVEYOR_REPO_BRANCH --commitAuthor $env:APPVEYOR_REPO_COMMIT_AUTHOR --commitEmail $env:APPVEYOR_REPO_COMMIT_AUTHOR_EMAIL --commitMessage $env:APPVEYOR_REPO_COMMIT_MESSAGE --jobId $env:APPVEYOR_JOB_ID}
}

task postbuild -depends coverage-only, coveralls-only

task appveyor-build -depends RestoreNuGetPackages, build

task appveyor-test -depends AppVeyorTestSettings, postbuild
