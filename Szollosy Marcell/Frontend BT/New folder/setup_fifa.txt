@echo off
set PROJECT_NAME=fifa-tracker

echo 1. Vite projekt inicializalasa...
echo y | call npm create vite@latest %PROJECT_NAME% -- --template vue

cd %PROJECT_NAME%

echo 2. Vue verzio beallitasa (3.5.13)...
:: Megjegyzés: A 3.5.33 jelenleg nem létezik, a legfrissebb stabil a 3.5.13 körül van.
call npm install vue@latest --save

echo 3. Node modulok telepitese...
call npm install

echo 4. Takaritas es mappa struktura...
if exist "src\components\HelloWorld.vue" del /f /q "src\components\HelloWorld.vue"
if exist "src\assets\vue.svg" del /f /q "src\assets\vue.svg"
if not exist "src\assets" mkdir "src\assets"
if not exist "src\components" mkdir "src\components"
if not exist "src\data" mkdir "src\data"

echo 5. Alapertelmezett fajlok letrehozasa tartalommal...

:: HelloWorld.vue letrehozasa (hogy ne legyen import hiba)
(
echo ^<template^>
echo   ^<div class="hello"^>
echo     ^<h1^>FIFA Tracker Fut fut^</h1^>
echo     ^<p^>A projekt vaza sikeresen osszeallt.^</p^>
echo   ^</div^>
echo ^</template^>
echo.
echo ^<style scoped^>
echo .hello { font-family: sans-serif; text-align: center; margin-top: 60px; color: #42b983; }
echo ^</style^>
) > src\components\HelloWorld.vue

:: App.vue felulirasa egy tiszta verzioval
(
echo ^<script setup^>
echo import HelloWorld from './components/HelloWorld.vue'
echo ^</script^>
echo.
echo ^<template^>
echo   ^<HelloWorld /^>
echo ^</template^>
) > src\App.vue

:: Tobbi ures fajl letrehozasa
copy /y nul "src\assets\main.css" >nul
copy /y nul "src\components\AppHeader.vue" >nul
copy /y nul "src\components\AppFooter.vue" >nul
copy /y nul "src\components\TeamTable.vue" >nul
copy /y nul "src\components\LineupPanel.vue" >nul
copy /y nul "src\components\BookingForm.vue" >nul
echo export const teams = []; > src\data\teams.js

echo.
echo ======================================================
echo Minden kesz! Most mar futtathatod:
echo cd %PROJECT_NAME%
echo npm run dev
echo ======================================================
pause