const Esemenyek = [
{
    nev: "Éves Cégkonferencia",
    datum: '2025-11-20',
    helyszin: "Budapest Kongresszusi Központ",
    resztvevok: ["Péte", "Anna", "Gábor", "Zsuzsa", "István"],
    kategoria: 'Konferencia'
},
{
    nev: "Maratoni Futóverseny",
    datum: '2025-10-15',
    helyszin: "Margitsziget",
    resztvevok: ["Béla", "Kati", ],
    kategoria: 'Sport'
},
{
    nev: "Kortárs Művészeti Kiállítás",
    datum: '2025-12-01',
    helyszin: "Műcsarnok",
    resztvevok: ["László", "Anna", "Mariann", "Zsuzsa",],
    kategoria: 'Kultúra'
}
];
function kiirLista(tomb,elemID) {
    const ul = document.getElementById(elemID);
    ul.innerHTML = '';

    for (const esemeny of tomb) {
        const li = document.createElement('li');

        const resztvevokString = esemeny.resztvevok.join(', ');

        li.innerHTML = `
        <strong>${esemeny.nev}</strong> (${esemeny.datum})
        <br>
        &nbsp;&nbsp;&nbsp;Helyszín: ${esemeny.helyszin}, kategoria: ${esemeny.kategoria}
        <br>
        &nbsp;&nbsp;&nbsp;Résztvevők (${esemeny.resztvevok.length} fő): &{resztvevokString}
        `;
        ul.appendChild(li);
    }
}