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

/**
 * Code for the mode buttons that change the tier list
 */
document.addEventListener("DOMContentLoaded", function () {

    const buttons = document.querySelectorAll(".mode-btn");
    const characters = document.querySelectorAll(".character-card");

    function updateTierList(mode) {

        document.querySelectorAll(".tier-container").forEach(c => c.innerHTML = "");

        characters.forEach(char => {

            let tier = char.dataset[mode];
            let role = char.dataset.role;

            if (!tier || !role) return;

            let container = document.querySelector(
                `.tier[data-tier="${tier}"] 
             .role-column[data-role="${role}"] 
             .tier-container`
            );

            if (container) {
                container.appendChild(char);
            }
        });
    }

    // Default
    updateTierList("as");

    buttons.forEach(btn => {
        btn.addEventListener("click", function () {

            buttons.forEach(b => b.classList.remove("active"));
            this.classList.add("active");

            updateTierList(this.dataset.mode);
        });
    });

});