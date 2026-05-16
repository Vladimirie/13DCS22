<script setup>
import { ref } from 'vue';
    const test = ref('Blue');
    const binding = ref('b');
    const model = ref('');
    const isBlue = ref(true);
    const cats = ['Cica', 'Cirmos', 'Tigris'];

function colorChange(){
    if (binding.value == 'b') {
        binding.value = 'c'; 
        test.value = 'Coral';
        isBlue.value = !isBlue.value;
    }else{
        binding.value = 'b';
        test.value = 'Blue';
        isBlue.value = !isBlue.value;
    }
}
</script>

<template>
    <h1 :class="binding">{{test}}</h1>
    <button @click="colorChange">Change Color </button>
    <input v-model="model">
    <p>{{  model  }}</p>
    <h1 v-if="isBlue"></h1>
    <h1 v-else>The text is not Blue</h1>
  <!---!><h1 v-else-if=""></h1><!-->
    <h1 v-for="cat in cats">{{ cat }}</h1>
</template>

<style>
.b {
    color: blue;
}
.c {
    color: rgb(255, 72, 0);
}

</style>