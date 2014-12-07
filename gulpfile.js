var gulp = require('gulp'),
    assemblyInfo = require('gulp-dotnet-assembly-info'),
    msbuild = require('gulp-msbuild'),
    MSTest = require('mstest');

gulp.task('assemblyInfo', function() {
    var buildVersion = '0.1.0.0';

    return gulp
        .src('**/AssemblyInfo.cs')
        .pipe(assemblyInfo({
            version: buildVersion,
            fileVersion: buildVersion,
        }))
        .pipe(gulp.dest('.'));
});

gulp.task('build', [], function () {
    return gulp
        .src('**/*.sln')
        .pipe(msbuild({
            toolsVersion: 12.0,
            targets: ['Clean', 'Build'],
            errorOnFail: true,
            stdout: true
        }));
});

gulp.task('test', ['build'], function (callback) {
    //return gulp
    //    .src(['**/bin/**/*Tests.dll'], { read: false })
    //    .pipe(nunit({
    //        teamcity: true
    //    }));
    var msTest = new MSTest();
    msTest.testContainer = 'src/BCLExtensions.Tests/bin/Release/BCLExtensions.Tests.dll';
    msTest.details.errorMessage = true;
    msTest.details.errorStackTrace = true;
    msTest.runTests({
        eachTest: function (test) {
            console.log(test.status + ' - ' + test.name);
        },
        done: function (results, passed, failed) {
            console.log(passed.length + '/' + results.length);
            if (passed.length < results.length) {
                return callback(new Error(0, passed.length + '/' + results.length + " Passed"));
            }
            callback()
        }
    });
});

gulp.task('default', []);

gulp.task('ci', []);