<script setup>
import Home from './list.vue';
</script>

<template>
  <h1>Cica</h1>
  <p>
    Visit <a href="https://vuejs.org/" target="_blank" rel="noopener">vuejs.org</a> to read the
    documentation
  </p>
  <nav>
  <RouterLink to="/">Cica</RouterLink>
  <RouterLink to="/list">List </RouterLink>
  </nav>

  <home/>
</template>

<style scoped>
@import 'style.css';
</style>
