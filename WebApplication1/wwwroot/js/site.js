// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function initializeToggleButtons() {
    document.querySelectorAll(".toggle-btn").forEach(btn => {
        btn.removeEventListener("click", toggleButton)
        btn.addEventListener("click", toggleButton) 
        
    });
}

function toggleButton() {
    this.classList.toggle("highlight");
}

document.addEventListener("DOMContentLoaded", () => {
    initializeToggleButtons();
});

console.log("toggleButtons.js loaded");