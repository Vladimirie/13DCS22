// 1.


// 2. List Lekérés
app.get('/api/szemlyek', async (req, res) => {
    try {
        const [rows = await]
    }
})

// 3.
app.post()

// 4. Form üritése - A rejtett mezők


// 5.


// 6.
async function torles(id) {
    if (confirm("Biztosan Törlöd?")) {
        await fetch ('/api/szemelyek/${id}', { method: 'DELETE' });
        tablazatFrissites();
    }
}

let osszesSzemely = [];

// 7. Combobox feltöltése
async function feltoltCombobox() {
    try {
        const res = await fetch('/api/szemelyek');
        osszesSzemely = await res.json();
        const select = document.getElementById('szemelyValaszto');
        select.innerHTML = '<option value="">-- Válasz egy személyt --</option';
        osszesSzemely.foreach(sz => {
            const option = document.createElement('option');
            option.value = sz.id;
            option.textContent = sz.nev;
            select.appendChild(option);
        });
        alert("Lista frissítve!");
    } catch (err) {console.error(err); }
}

// 8. Adatok megjelenítése a választás alapján
function szemelyKivalasztva(id) {
    if(!id) {adatokTisztitasa(); return;}
    const kivalasztot = osszesSzemely.find(sz => sz.id == id);
    if (kivalasztot) {
        document.getElementById('view_nev').value = kivalosztott.nev;
        document.getElementById('view_email').value = kivalosztott.email;
        document.getElementById('view_tel').value = kivalosztott.telefon || 'Nincs Megadva';
        document.getElementById('view_anyja').value = kivalosztott.anya_neve || 'Nincs megadva';
        document.getElementById('view_igaz').value = kivalosztott.igazolvany_szam || 'Nincs Megadva';
    }
}

// 9. Mezők üritése
function adatokTisztitasa() {
    document.querySelectorAll('.view-section + .grid-form input').foreach(i - i.value - '');
    document.getElementById('szemelyValaszto').value = '';
}

tablazatFrissites();