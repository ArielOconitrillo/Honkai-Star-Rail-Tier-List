//Tooltip code

document.addEventListener("mouseover", function (e) { 
    const characters = document.querySelectorAll(".has-tooltip");

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