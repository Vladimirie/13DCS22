let db;
const dbNev = "RegisztracioDB";
const dbVerzio = 3;

// Adatbázis megnyitása
const openRequest = indexedDB.open(dbNev, dbVerzio);

// Ez az esemény akkor fut le, ha az adatbázis még nem létezik vagy a verziószám magasabb.
openRequest.onupgradeneeded = (e) => {
    db = e.target.result;
    // Létrehozzuk a "felhasznalok" objektumtárat, ha még nem létezik
    if (!db.objectStoreNames.contains('felhasznalok')) {
        const objectStore = db.createObjectStore("felhasznalok", { keyPath: "email" });
        objectStore.createIndex("jelszo", "jelszo", { unique: false });
        console.log("Adatbázis struktúra sikeresen létrehozva.");
    }
};

openRequest.onerror = (e) => {
    console.error("Adatbázis hiba:", e.target.error);
};

// Ez az esemény akkor fut le, ha az adatbázis sikeresen megnyílt.
openRequest.onsuccess = (e) => {
    db = e.target.result;
    console.log("Adatbázis sikeresen megnyitva.");

    // Váltás a Regisztráció és Bejelentkezés űrlapok között
    /*
    document.getElementById('toggleLink').addEventListener('click', function (event) {
        event.preventDefault();
        const loginContainer = document.getElementById('loginFormContainer');
        const regContainer = document.getElementById('registrationFormContainer');
        const link = document.getElementById('toggleLink');

        if (loginContainer.classList.contains('hidden')) {
            loginContainer.classList.remove('hidden');
            regContainer.classList.add('hidden');
            link.textContent = 'Már van fiókod? Jelentkezz be!';
        } else {
            loginContainer.classList.add('hidden');
            regContainer.classList.remove('hidden');
            link.textContent = 'Még nincs fiókod? Regisztrálj!';
        }
        document.getElementById('message').textContent = '';
    });*/

    // Regisztrációs űrlap kezelése validációval és IndexedDB-vel
    document.getElementById('registrationForm').addEventListener('submit', function (event) {
        event.preventDefault();
        const emailInput = document.getElementById('regEmail');
        const passwordInput = document.getElementById('regPassword');
        const messageDiv = document.getElementById('message');

        // Email validáció
        if (!validateEmail(emailInput.value)) {
            messageDiv.style.color = 'red';
            messageDiv.textContent = 'Érvénytelen email cím formátum.';
            return;
        }

        // Jelszó validáció
        const password = passwordInput.value;
        const passwordError = validatePassword(password);
        if (passwordError) {
            messageDiv.style.color = 'red';
            messageDiv.textContent = passwordError;
            return;
        }

        // A validáció sikeres, most megpróbáljuk elmenteni az adatbázisba
        const tranzakcio = db.transaction(["felhasznalok"], "readwrite");
        const objectStore = tranzakcio.objectStore("felhasznalok");
        const hozzaadasKeres = objectStore.add({ email: emailInput.value, jelszo: password });

        hozzaadasKeres.onsuccess = () => {
            messageDiv.style.color = 'green';
            messageDiv.textContent = 'Sikeres regisztráció! Jelentkezz be.';
            document.getElementById('registrationForm').reset();
            // Átváltás a bejelentkezési űrlapra
            document.getElementById('loginFormContainer').classList.remove('hidden');
            document.getElementById('registrationFormContainer').classList.add('hidden');
            document.getElementById('toggleLink').textContent = 'Már van fiókod? Jelentkezz be!';
        };

        hozzaadasKeres.onerror = (e) => {
            messageDiv.style.color = 'red';
            if (e.target.error.name === "ConstraintError") {
                messageDiv.textContent = 'Hiba: Ez az e-mail cím már regisztrálva van.';
            } else {
                messageDiv.textContent = 'Hiba a regisztráció során.';
            }
        };
    });

    // Bejelentkezési űrlap kezelése validációval és IndexedDB-vel
    document.getElementById('loginForm').addEventListener('submit', function (event) {
        event.preventDefault();
        const messageDiv = document.getElementById('message');
        const emailInput = document.getElementById('loginEmail');
        const passwordInput = document.getElementById('loginPassword');

        // Email validáció
        if (!validateEmail(emailInput.value)) {
            messageDiv.style.color = 'red';
            messageDiv.textContent = 'Érvénytelen email cím formátum.';
            return;
        }

        // A jelszó validációja
        const password = passwordInput.value;
        const passwordError = validatePassword(password);
        if (passwordError) {
            messageDiv.style.color = 'red';
            messageDiv.textContent = passwordError;
            return;
        }

        // Adatbázis tranzakció
        const tranzakcio = db.transaction(["felhasznalok"], "readonly");
        const objectStore = tranzakcio.objectStore("felhasznalok");
        const getRequest = objectStore.get(emailInput.value);

        getRequest.onsuccess = (e) => {
            const felhasznalo = e.target.result;
            if (felhasznalo && felhasznalo.jelszo === password) {
                messageDiv.style.color = 'green';
                messageDiv.textContent = 'Sikeres bejelentkezés! Átirányítás...';
                // Átirányítás a főoldalra
                window.location.href = 'dashboard.html';
            } else {
                messageDiv.style.color = 'red';
                messageDiv.textContent = 'Hibás e-mail cím vagy jelszó.';
            }
        };

        getRequest.onerror = () => {
            messageDiv.style.color = 'red';
            messageDiv.textContent = 'Hiba történt a bejelentkezés során.';
        };
    });
};

// JavaScript email validációs függvény
function validateEmail(email) {
    const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}

// JavaScript jelszó validációs függvény
function validatePassword(password) {
    if (password.length < 8) {
        return 'A jelszónak legalább 8 karakter hosszúnak kell lennie.';
    }
    if (!/[a-zA-Z]/.test(password)) {
        return 'A jelszónak tartalmaznia kell legalább egy betűt.';
    }
    if (!/\d/.test(password)) {
        return 'A jelszónak tartalmaznia kell legalább egy számot.';
    }
    return null; // A jelszó érvényes
}
