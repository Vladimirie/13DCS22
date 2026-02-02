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

:: 5. server.js létrehozása a megadott adatokkal
echo [LOG] server.js letrehozasa a kapcsolat adatokkal...
(
echo // MySQL Kapcsolati adatok
echo const db_config = {
echo   host: "37.221.209.228",
echo   port: 40180,
echo   user: "ajax",
echo   password: "Password123",
echo   database: "ajaxteszt"
echo };
echo.
echo console.log("Adatbazis konfiguracio betoltve.");
) > server.js

echo [LOG] --- Folyamat befejezodott! ---
echo [LOG] A projekt mappaja: %PROJECT_NAME%
pause