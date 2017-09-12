var gulp = require('gulp');
var uglify = require('gulp-uglify');
var concat = require('gulp-concat');
var rename = require('gulp-rename');
var cssmin = require('gulp-cssmin');
var watch = require('gulp-watch');

var filesCss = [
    'wwwroot/lib/materialize/dist/css/materialize.css',
    'wwwroot/css/custom.css'
];

var filesJs = [
    'wwwroot/lib/jquery/dist/jquery.js',
    'wwwroot/lib/jquery-validation/dist/jquery.validate.js',
    'wwwroot/lib/materialize/dist/js/materialize.js',
    'wwwroot/js/scripts.js'
];

gulp.task('minify-css', function () {
    gulp.src(filesCss)
        .pipe(concat('site.min.css'))
        .pipe(cssmin())
        .pipe(gulp.dest('./wwwroot/css/'));
});

gulp.task('minify-js', function () {
    gulp.src(filesJs)
        .pipe(concat('site.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest('./wwwroot/js/'));
});

gulp.task('default', ['minify-css', 'minify-js']);

gulp.task('watch', function () {
    gulp.watch(filesCss, ['minify-css']);
    gulp.watch(filesJs, ['minify-js']);
});