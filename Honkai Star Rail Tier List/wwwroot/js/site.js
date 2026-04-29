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

//Filters for the tier list
let activeFilters = {
    rarity: [],
    path: [],
    element: []
};

let currentMode = "as";
let searchQuery = "";

/**
 * Code for the mode/filter buttons that change the tier list
 */
document.addEventListener("DOMContentLoaded", function () {

    const buttons = document.querySelectorAll(".mode-btn");
    const characters = document.querySelectorAll(".has-tooltip");

    //Function for tier list filtering.sorting
    function updateTierList(mode) {

        document.querySelectorAll(".tier-container").forEach(c => c.innerHTML = "");

        characters.forEach(char => {

            let tier = char.dataset[mode];
            let role = char.dataset.role;

            if (!matchesFilters(char)) return;

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

    //Function for characters or light cone page filtering
    function updateGrid(selector) {
        const items = document.querySelectorAll(selector);

        items.forEach(el => {
            const hidden = !matchesFilters(el);
            el.style.display = hidden ? "none" : "";
        });
    }

    function matchesFilters(el) {
        //Name filter
        if (searchQuery) {
            const name = (el.dataset.name || "").toLowerCase();

            if (!name.includes(searchQuery)) {
                return false;
            }
        }

        //Other filters
        for (const key in activeFilters) {
            const values = activeFilters[key];

            if (values.length === 0) continue;

            const dataValue = el.dataset[key];

            if (!dataValue) continue;

            if (!values.includes(dataValue)) {
                return false;
            }
        }

        return true;
    }

    function runFilters() {
        if (document.querySelector(".tier-container")) {
            updateTierList(currentMode);
        } else if (document.querySelector(".characters-list")) {
            updateGrid(".has-tooltip");
        } else if (document.querySelector(".light-cone-grid")) {
            updateGrid(".light-cone");
        }
    }


    // Default
    updateTierList("as");

    const defaultBtn = document.querySelector(`.mode-btn[data-mode="${currentMode}"]`);
    defaultBtn?.classList.add("active");

    buttons.forEach(btn => {
        btn.addEventListener("click", function () {

            currentMode = this.dataset.mode;

            buttons.forEach(b => b.classList.remove("active"));
            this.classList.add("active");

            if (document.querySelector(".tier-container")) {
                updateTierList(currentMode);
            } else if (document.querySelector(".characters-list")) {
                updateGrid(".has-tooltip");
            } else if (document.querySelector(".light-cone-grid")) {
                updateGrid(".light-cone");
            }
        });
    });

 /*
 * Code for the filter buttons
 */
    const filterButtons = document.querySelectorAll(".filter-btn");

    filterButtons.forEach(btn => {
        btn.addEventListener("click", function () {

            const filterType = this.dataset.filter;
            const value = this.dataset.value;

            let filterArray = activeFilters[filterType];

            if (filterArray.includes(value)) {
                activeFilters[filterType] = filterArray.filter(v => v !== value);
                this.classList.remove("active");
            } else {

                filterArray.push(value);
                this.classList.add("active");
            }

            if (document.querySelector(".tier-container")) {
                updateTierList(currentMode);
            } else if (document.querySelector(".characters-list")) {
                updateGrid(".has-tooltip");
            } else if (document.querySelector(".light-cone-grid")) {
                updateGrid(".light-cone");
            }

            this.blur();
        });
    });

    document.querySelectorAll(".clear-filter-btn").forEach(btn => {
        btn.addEventListener("click", function () {
            clearFilter(this.dataset.filter);
        });
    });

    const clearAllBtn = document.getElementById("clearAllFiltersBtn");

    if (clearAllBtn) {
        clearAllBtn.addEventListener("click", function () {

            activeFilters = {
                rarity: [],
                path: [],
                element: []
            };

            document.querySelectorAll(".filter-btn")
                .forEach(btn => btn.classList.remove("active"));

            if (searchInput) {
                searchInput.value = "";
                searchQuery = "";
            }

            if (clearSearchBtn) {
                clearSearchBtn.style.display = "none";
            }

            runFilters();

            this.blur();
        });
    }

    function clearFilter(filterType) {

        activeFilters[filterType] = [];

        document.querySelectorAll(`.filter-btn[data-filter="${filterType}"]`)
            .forEach(btn => btn.classList.remove("active"));

        if (document.querySelector(".tier-container")) {
            updateTierList(currentMode);
        } else if (document.querySelector(".characters-list")) {
            updateGrid(".has-tooltip");
        } else if (document.querySelector(".light-cone-grid")) {
            updateGrid(".light-cone");
        }
    }

    //Name search
    let searchTimeout;
    const searchInput = document.getElementById("searchInput");
    const clearSearchBtn = document.getElementById("clearSearchBtn");

    document.getElementById("searchInput").addEventListener("input", function () {
        clearTimeout(searchTimeout);

        searchTimeout = setTimeout(() => {
            searchQuery = this.value.toLowerCase().trim();

            if (document.querySelector(".tier-container")) {
                updateTierList(currentMode);
            } else if (document.querySelector(".characters-list")) {
                updateGrid(".has-tooltip");
            } else if (document.querySelector(".light-cone-grid")) {
                updateGrid(".light-cone");
            }
        }, 150);
    });

    if (searchInput) {
        searchInput.addEventListener("input", function () {
            searchQuery = this.value.toLowerCase().trim();

            clearSearchBtn.style.display = this.value ? "block" : "none";

            runFilters();
        });
    }

    // Click X → clear search
    if (clearSearchBtn) {
        clearSearchBtn.addEventListener("click", function () {
            searchInput.value = "";
            searchQuery = "";
            clearSearchBtn.style.display = "none";

            runFilters();
        });
    }

    //Tooltip code

    document.addEventListener("mouseover", function (e) {
        const char = e.target.closest(".has-tooltip");
        if (!char) return;

        const tooltip = document.getElementById("character-tooltip");

        const rarity = char.dataset.rarity;
        const path = char.dataset.path;
        const element = char.dataset.element;
        const as = char.dataset.as;
        const moc = char.dataset.moc;
        const pf = char.dataset.pf;
        const name = char.dataset.name;

        tooltip.innerHTML = `
        <div class="character-tooltip-name">${name}</div>
            <div>${rarity}★</div>
            <div><img src="/Images/Elements/${element}.webp" width="20"> ${element}</div>
            <div><img src="/Images/Paths/${path}.webp" width="20"> ${path}</div>
            <hr>
            <div class="character-tooltip-tiers">
                <div class="tier-box">
                    <div class="tier-value ${as}">${as}</div>
                    <div class="tooltip-label">AS</div>
                </div>

                <div class="tier-box">
                    <div class="tier-value ${moc}">${moc}</div>
                    <div class="tooltip-label">MoC</div>
                </div>

                <div class="tier-box">
                    <div class="tier-value ${pf}">${pf}</div>
                    <div class="tooltip-label">PF</div>
                </div>
            </div>
    `;

        tooltip.style.display = "block";

        const rect = char.getBoundingClientRect();

        tooltip.style.left = rect.left + rect.width / 2 + "px";
        tooltip.style.top = rect.top - tooltip.offsetHeight - 10 + "px";
        tooltip.style.transform = "translateX(-50%)";
    });

    document.addEventListener("mouseout", function (e) {
        const char = e.target.closest(".has-tooltip");
        if (!char) return;

        document.getElementById("character-tooltip").style.display = "none";
    });

});

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