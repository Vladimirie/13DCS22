
const nyersAdatok = [
    { nev: "Kiss Anna", tantargy: "Programozás", hianyzas: 5, igazolt: true, tipus: "Orvosi" },
    { nev: "Nagy Bence", tantargy: "Adatbázis", hianyzas: 2, igazolt: false, tipus: "" },
    { nev: "Varga Dóra", tantargy: "Programozás", hianyzas: 8, igazolt: true, tipus: "Szülői" },
    { nev: "Tóth Gábor", tantargy: "Frontend", hianyzas: 10, igazolt: false, tipus: "" },
    { nev: "Mészáros Eszter", tantargy: "Programozás", hianyzas: 3, igazolt: true, tipus: "Orvosi" }
];

function egyediTantargyak() {
    const tantargySet = new Set(
        nyersAdatok.map(adat => adat.tantargy)
    );

    const select = document.getElementById("tantargySzuro");

    tantargySet.forEach(tantargy => {
        const option = document.createElement("option");
        option.value = tantargy;
        option.textContent = tantargy;
        select.appendChild(option);
    });
}


function osszesitettHianyzasok() {
    const map = new Map();

    nyersAdatok.forEach(adat => {
        const eddigi = map.get(adat.nev) || 0;
        map.set(adat.nev, eddigi + adat.hianyzas);
    });

    return map;
}

function igazolatlanHianyzasok() {
    return nyersAdatok.filter(adat => !adat.igazolt);
}


function mindenkiBeleferALimitbe(limit) {
    const igazolatlan = igazolatlanHianyzasok();

    return igazolatlan.every(adat => adat.hianyzas < limit);
}

function tablaGeneralas(adatok) {
    if (adatok.length === 0) {
        return "<p>Nincs megjeleníthető adat.</p>";
    }

    const sorok = adatok.map(adat => `
        <tr>
            <td>${adat.nev}</td>
            <td>${adat.tantargy}</td>
            <td>${adat.hianyzas}</td>
            <td>${adat.igazolt ? "Igen" : "Nem"}</td>
            <td>${adat.tipus || "-"}</td>
        </tr>
    `);

    return `
        <table>
            <thead>
                <tr>
                    <th>Név</th>
                    <th>Tantárgy</th>
                    <th>Hiányzás</th>
                    <th>Igazolt</th>
                    <th>Típus</th>
                </tr>
            </thead>
            <tbody>
                ${sorok.join("")}
            </tbody>
        </table>
    `;
}


document.getElementById("szuroForm")
    .addEventListener("submit", function (event) {
        event.preventDefault();

        const minIgazolatlan =
            Number(document.getElementById("minIgazolatlan").value);

        const tantargy =
            document.getElementById("tantargySzuro").value;

        let szurtAdatok = nyersAdatok;

        
        if (tantargy) {
            szurtAdatok = szurtAdatok.filter(
                adat => adat.tantargy === tantargy
            );
        }

        
        szurtAdatok = szurtAdatok.filter(adat => {
            if (adat.igazolt) return true;
            return adat.hianyzas >= minIgazolatlan;
        });

        document.getElementById("eredmenyek")
            .innerHTML = tablaGeneralas(szurtAdatok);

        
        const limitOk = mindenkiBeleferALimitbe(minIgazolatlan);
        const limitDiv = document.getElementById("limitEllenorzes");

        limitDiv.innerHTML = limitOk
            ? `<p class="ok">✅ Mindenki belefér a megadott limitbe.</p>`
            : `<p class="hiba">❌ Van diák, aki túllépte a limitet.</p>`;
    });


egyediTantargyak();
