@echo off
set PROJECT_NAME=ajax-nodejs_projekt

echo [LOG] --- Folyamat kezdete: %PROJECT_NAME% ---

:: 1. Mappastruktúra létrehozása
echo [LOG] Mappak letrehozasa...
mkdir %PROJECT_NAME%
cd %PROJECT_NAME%
mkdir public

:: 2. Üres fájlok létrehozása
echo [LOG] Ures fajlok letrehozasa...
type nul > public\index.html
type nul > public\style.css
type nul > public\script.js

:: 3. Node.js / NPM inicializálás
echo [LOG] NPM inicializalasa...
call npm init -y > nul

:: 4. Csomagok telepítése (express és mysql2)
echo [LOG] Express es Mysql2 telepitese...
call npm install express mysql2 --save

:: 5. server.js létrehozása soronként (biztonságosabb módszer)
echo [LOG] server.js letrehozasa...

echo const express = require('express'); > server.js
echo const mysql = require('mysql2/promise'); >> server.js
echo const app = express(); >> server.js
echo. >> server.js
echo const db_config = { >> server.js
echo   host: "37.221.209.228", >> server.js
echo   port: 40180, >> server.js
echo   user: "ajax", >> server.js
echo   password: "Password123", >> server.js
echo   database: "CarMaintance" >> server.js
echo }; >> server.js
echo. >> server.js
echo app.use(express.json()); >> server.js
echo app.use(express.static('public')); >> server.js
echo. >> server.js
echo app.get('/', (req, res) =^> { >> server.js
echo   res.sendFile(__dirname + '/public/index.html'); >> server.js
echo }); >> server.js
echo. >> server.js
echo const PORT = 3000; >> server.js
echo app.listen(PORT, () =^> { >> server.js
echo   console.log("========================================"); >> server.js
echo   console.log("Szerver sikeresen elindult!"); >> server.js
echo   console.log("Elerheto: http://localhost:" + PORT); >> server.js
echo   console.log("Leallitashoz: Ctrl+C"); >> server.js
echo   console.log("========================================"); >> server.js
echo }); >> server.js

echo [LOG] --- Folyamat befejezodott! ---
echo [LOG] A projekt mappaja: %PROJECT_NAME%
echo [LOG] Inditashoz: cd %PROJECT_NAME% majd node server.js
pause