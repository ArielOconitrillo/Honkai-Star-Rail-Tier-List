// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*
* Accordian code taken from W3Schools: https://www.w3schools.com/howto/tryit.asp?filename=tryhow_js_accordion_symbol
*/
var acc = document.getElementsByClassName("accordion");
var i;

for (i = 0; i < acc.length; i++) {
    acc[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var panel = this.nextElementSibling;
        if (panel.style.maxHeight) {
            panel.style.maxHeight = null;
        } else {
            panel.style.maxHeight = panel.scrollHeight + "px";
        }
    });
}

document.addEventListener("DOMContentLoaded", function () {

    const sliders = document.querySelectorAll(".skill-slider");

    sliders.forEach(slider => {

        const display = document.getElementById(slider.dataset.display);
        const container = document.getElementById(slider.dataset.container);
        const values = JSON.parse(slider.dataset.values);

        if (!display || !container) return;

        function updateLevel(level) {

            display.textContent = level;

            const stats = values.filter(v => v.level === level);

            stats.forEach(stat => {

                const element = container.querySelector(
                    `[data-stat="${stat.statType}"]`
                );

                if (element) {
                    element.textContent = stat.value;
                }

            });

        }

        slider.addEventListener("input", function () {
            updateLevel(parseInt(this.value));
        });

        updateLevel(parseInt(slider.value));

    });

});