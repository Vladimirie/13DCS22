function kalkulal() {
    const szelesseg = Number(document.getElementById("szelesseg").value);
    const magassag = Number(document.getElementById("magassag").value);

    const terulet = szelesseg * magassag;
    const papir = 120;

    const koltseg = terulet * papir / 1000000;

    document.getElementById("valasz").innerHTML =
        "Terület: " + terulet + " mm²<br>" +
        "Papír tömeg: " + papir + " g/m²<br>" +
        "Költség: " + koltseg.toFixed(2) + " Ft";

    document.getElementById("valasz").style.display = "block";
}
