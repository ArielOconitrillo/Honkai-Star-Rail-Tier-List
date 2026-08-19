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

    const characters = document.querySelectorAll(".tier-character");
    const buttons = document.querySelectorAll(".mode-btn");

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
    function updateGrid(selector, label) {
        const items = document.querySelectorAll(selector);

        items.forEach(el => {
            const hidden = !matchesFilters(el);
            el.style.display = hidden ? "none" : "";
        });

        updateCount(selector, label);
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
            updateGrid(".has-tooltip", "characters");
        } else if (document.querySelector(".light-cone-grid")) {
            updateGrid(".light-cone", "light cones");
        }
    }

    //Function for upadting the count after selecting filters
    function updateCount(selector, label) {
        const items = document.querySelectorAll(selector);

        let visibleCount = 0;

        items.forEach(el => {
            if (el.style.display !== "none") {
                visibleCount++;
            }
        });

        const countEl = document.getElementById("item-count");

        if (countEl) {
            countEl.textContent = visibleCount === 1
                ? `Displaying 1 ${label.slice(0, -1)}`
                : `Displaying ${visibleCount} ${label}`;
        }
    }


    // Default
    if (document.querySelector(".tier-container")) {
        updateTierList("as");

        const defaultBtn = document.querySelector(`.mode-btn[data-mode="${currentMode}"]`);
        defaultBtn?.classList.add("active");
    }

    buttons.forEach(btn => {
        btn.addEventListener("click", function () {

            currentMode = this.dataset.mode;

            buttons.forEach(b => b.classList.remove("active"));
            this.classList.add("active");

            runFilters();
        });
    });

    /*
    * Code for the filter buttons
    */
    const filterButtons = document.querySelectorAll(
        ".filter-btn:not(.clear-filter-btn)"
    );

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

            runFilters();

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

        runFilters();
    }

    //Name search
    let searchTimeout;
    const searchInput = document.getElementById("searchInput");
    const clearSearchBtn = document.getElementById("clearSearchBtn");

    if (searchInput) {
        searchInput.addEventListener("input", function () {

            clearTimeout(searchTimeout);

            searchTimeout = setTimeout(() => {

                searchQuery = this.value.toLowerCase().trim();

                runFilters();

            }, 150);

            clearSearchBtn.style.display = this.value ? "block" : "none";
        });
    }

    if (clearSearchBtn) {
        clearSearchBtn.addEventListener("click", function () {
            searchInput.value = "";
            searchQuery = "";
            clearSearchBtn.style.display = "none";

            runFilters();
        });
    }
});