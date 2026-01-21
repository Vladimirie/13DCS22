const express = require('express');
const mysql = require('mysql2/promise');
const app = express();

const db_config = { 
  host: "37.221.209.228", 
  port: 40180, 
  user: "ajax", 
  password: "Password123", 
  database: "ajaxteszt" 
}; 

app.use(express.json());
app.use(express.static('Public'));
const pool = mysql.createPool(db_config);
 
console.log("Adatbazis konfiguracio betoltve."); 

app.listen(3000, () => console.log('Szerver: http//localhost:3000'));

