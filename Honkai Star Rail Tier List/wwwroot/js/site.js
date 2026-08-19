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

/**
 * Character details page tab button code
 */
document.querySelectorAll(".character-tab-btn").forEach(btn => {
    btn.addEventListener("click", function () {

        const tab = this.dataset.tab;

        document.querySelectorAll(".character-tab-btn")
            .forEach(b => b.classList.remove("active"));

        document.querySelectorAll(".character-panel")
            .forEach(p => p.classList.remove("active"));

        this.classList.add("active");

        document.getElementById(tab).classList.add("active");
    });
});