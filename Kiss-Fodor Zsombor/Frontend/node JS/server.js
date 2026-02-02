const express = require('express'); 
const mysql = require('mysql2/promise'); 
const app = express(); 
 
const db_config = { 
  host: "37.221.209.228:40180", 
  port: 40180, 
  user: "ajax", 
  password: "Password123", 
  database: "CarMaintance"
  //table: "Owner"
}; 

const con = mysql.createConnection({
  host: db_config.host,
  user: db_config.user,
  password: db_config.password,
  database: db_config.database
});
 
app.use(express.json()); 
app.use(express.static('public')); 
 
app.get('/', (req, res) => { 
  res.sendFile(__dirname + '/public/index.html'); 
}); 
 
const PORT = 3000; 
app.listen(PORT, () => { 
  console.log("========================================"); 
  console.log("Szerver sikeresen elindult!"); 
  console.log("Elerheto: http://localhost:" + PORT); 
  console.log("Leallitashoz: Ctrl+C"); 
  console.log("========================================"); 
}); 

app.get('/api/owners', (req, res) => {
  res.json(con.query("SELECT * FROM Owner "));
});