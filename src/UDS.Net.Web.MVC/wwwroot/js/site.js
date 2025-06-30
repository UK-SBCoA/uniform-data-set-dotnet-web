// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("turbo:load", function () {
  console.log("turbo:load event");
});

document.addEventListener('turbo:visit', function (e) {
  console.log('turbo:visit', e);
});

document.addEventListener('turbo:frame-load', function (e) {
  console.log('turbo:frame-load', e);
});

document.addEventListener("turbo:before-cache", function () {
  // ...
  console.log('turbo:before-cache');
});