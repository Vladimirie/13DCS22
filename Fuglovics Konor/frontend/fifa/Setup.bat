@echo off
set ROOT=smart-home-vue-final

echo [1/4] Mappak letrehozasa...
mkdir %ROOT%
cd %ROOT%
mkdir src
mkdir src\assets
mkdir src\components
mkdir src\data

echo [2/4] Fajlok generalasa...

:: package.json
echo { > package.json
echo   "name": "smart-home", >> package.json
echo   "version": "1.0.0", >> package.json
echo   "type": "module", >> package.json
echo   "scripts": { "dev": "vite", "build": "vite build" } >> package.json
echo } >> package.json

:: vite.config.js
echo import { defineConfig } from 'vite' > vite.config.js
echo import vue from '@vitejs/plugin-vue' >> vite.config.js
echo export default defineConfig({ plugins: [vue()] }) >> vite.config.js

:: main.js
echo import { createApp } from 'vue' > src\main.js
echo import App from './App.vue' >> src\main.js
echo import './assets/main.css' >> src\main.js
echo createApp(App).mount('#app') >> src\main.js

:: main.css
echo body { font-family: sans-serif; background: #f4f4f4; } > src\assets\main.css
echo .card { background: white; padding: 15px; margin: 10px; border-radius: 8px; } >> src\assets\main.css

:: index.html
echo ^<html^>^<body^>^<div id="app"^>^</div^>^<script type="module" src="/src/main.js"^>^</script^>^</body^>^</html^> > index.html

:: AppHeader.vue
echo ^<template^>^<header^>^<h1^>Smart Home Header^</h1^>^</header^>^</template^> > src\components\AppHeader.vue

:: AppFooter.vue
echo ^<template^>^<footer^>^<p^>Smart Home Footer 2026^</p^>^</footer^>^</template^> > src\components\AppFooter.vue

:: teams.js
echo export const teams = [{id: 1, name: "Fejleszto Csapat"}]; > src\data\teams.js

:: App.vue
echo ^<script setup^> > src\App.vue
echo import AppHeader from './components/AppHeader.vue' >> src\App.vue
echo import AppFooter from './components/AppFooter.vue' >> src\App.vue
echo ^</script^> >> src\App.vue
echo ^<template^> >> src\App.vue
echo   ^<AppHeader /^> >> src\App.vue
echo   ^<main^>^<h1^>Smart Home Dashboard^</h1^>^</main^> >> src\App.vue
echo   ^<AppFooter /^> >> src\App.vue
echo ^</template^> >> src\App.vue

echo [3/4] Telepites inditasa (GYORSITOTT MOD)...
echo ---------------------------------------------------------
echo Biztonsagi ellenorzesek kihagyasa a sebesseg erdekeben...
echo ---------------------------------------------------------

:: A --no-audit es --no-fund kikapcsolja a lassu hálózati muveleteket
call npm install vue --loglevel info --no-audit --no-fund
call npm install -D vite @vitejs/plugin-vue --loglevel info --no-audit --no-fund

echo.
echo [4/4] KESZ! Minden fajl es fuggoseg a helyen.
echo ---------------------------------------------------------
echo Inditashoz:
echo 1. cd %ROOT%
echo 2. npm run dev
echo ---------------------------------------------------------
pause