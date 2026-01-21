@echo off
set PROJECT_NAME=ajax_node_projekt_setup


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

:: 4. Csomagok telepítése
echo [LOG] Express es Mysql2 telepitese...
call npm install express mysql2 --save

:: 5. server.js létrehozása (Biztonságosabb módszerrel)
echo [LOG] server.js generalasa...

echo const db_config = { > server.js
echo   host: "37.221.209.228", >> server.js
echo   port: 40180, >> server.js
echo   user: "ajax", >> server.js
echo   password: "Password123", >> server.js
echo   database: "ajaxteszt" >> server.js
echo }; >> server.js
echo. >> server.js
echo console.log("Adatbazis konfiguracio betoltve."); >> server.js

echo [LOG] --- FOLYAMAT BEFEJEZODOTT ---
echo [LOG] Ellenorizd a(z) %PROJECT_NAME% mappat!
pause