const express = require("express");
const mysql = require("mysql2");
const app = express();
const PORT = 3000;

// Statikus fájlok kiszolgálása
app.use(express.static("public"));

// Adatbázis kapcsolat
const db = mysql.createConnection({
  host: "37.221.209.228",
  port: 40180,
  user: "ajax",
  password: "Password123",
  database: "CarMaintance"
});

// Kapcsolódás ellenőrzése
db.connect(err => {
  if (err) {
    console.error("Adatbázis hiba:", err);
    return;
  }
  console.log("Sikeres adatbázis kapcsolat!");
});

// OWNER API – adatok lekérése
app.get("/api/owners", (req, res) => {
  try {
    const sql = "SELECT * FROM Owner";
    db.query(sql, (err, results) => {
      if (err) {
        res.status(500).json({ error: "Lekérdezési hiba" });
      } else {
        res.json(results);
      }
    });
  } catch (error) {
    res.status(500).json({ error: "Szerver hiba" });
  }
});

// Szerver indítása
app.listen(PORT, () => {
  console.log(`Szerver fut: http://localhost:${PORT}`);
});
