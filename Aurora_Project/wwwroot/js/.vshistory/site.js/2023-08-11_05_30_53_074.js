// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*document.addEventListener('DOMContentLoaded', function () {
    const navbar = document.getElementById('navbar');
    const scrollOffset = 100; // Adjust this value to control when the background color changes

    function updateNavbarColor() {
        if (window.scrollY >= scrollOffset) {
            navbar.classList.add('black');
        } else {
            navbar.classList.remove('black');
        }
    }

    // Call the function initially to set the initial state of the navbar
    updateNavbarColor();

    // Attach the function to the 'scroll' event to update the navbar while scrolling
    window.addEventListener('scroll', updateNavbarColor);
});