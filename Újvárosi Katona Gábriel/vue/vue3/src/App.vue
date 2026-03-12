<script setup>
import { ref } from 'vue';
import Header from './components/Header.vue';
import Footer from './components/Footer.vue';

import { devicesData } from './data/devices.js';
const devices = ref(devicesData);







</script>

<template>
<div class="app-container">
<Header />

<div class="content">
    <div class="input-group">

    </div>
</div>


<!-- <Footer />-->
<Footer ></Footer>
</div>





</template>