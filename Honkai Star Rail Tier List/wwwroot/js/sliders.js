/*
*   Code for the skill sliders
*/
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