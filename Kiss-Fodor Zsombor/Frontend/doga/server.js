const express = require("express");
const mysql = require("mysql2");
const path = require("path");

const app = express();
const PORT = 3000;

// JSON feldolgozás
app.use(express.json());

// Statikus fájlok (public mappa)
app.use(express.static(path.join(__dirname, "public")));

// Adatbázis kapcsolat
const db = mysql.createConnection({
    host: "37.221.209.228",
    port: 40180,
    user: "ajax",
    password: "Password123",
    database: "CarMaintance"
});

db.connect((err) => {
    if (err) {
        console.error("Hiba az adatbázis kapcsolódáskor:", err);
    } else {
        console.log("Sikeres adatbázis kapcsolat!");
    }
});


// ======================
// GET /api/cars
// ======================
app.get("/api/cars", (req, res) => {
    try {
        db.query("SELECT * FROM Cars", (err, results) => {
            if (err) {
                console.error(err);
                return res.status(500).json({ error: "Adatbázis hiba" });
            }
            res.json(results);
        });
    } catch (error) {
        res.status(500).json({ error: "Szerver hiba" });
    }
});


// ======================
// POST /api/cars/:id
// ======================
app.post("/api/cars/:id", (req, res) => {
    try {
        const carId = req.params.id;
        const { LicensePlate, Brand, Model , Year} = req.body;

        const sql = `
            UPDATE Cars 
            SET LicensePlate = ?, Brand = ?, Model = ?, Year = ?
            WHERE CarID = ?
        `;

        db.query(sql, [LicensePlate, Brand, Model, Year, carId], (err, result) => {
            if (err) {
                console.error(err);
                return res.status(500).json({ error: "Frissítési hiba" });
            }

            res.json({ message: "Sikeres módosítás!" });
        });

    } catch (error) {
        res.status(500).json({ error: "Szerver hiba" });
    }
});


app.listen(PORT, () => {
    console.log(`A szerver fut a http://localhost:${PORT} címen`);
});
