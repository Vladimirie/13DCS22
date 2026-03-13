<script setup> 
import {ref} from 'vue'

import AppHeader from './components/AppHeader.vue' 
import AppFooter from './components/AppFooter.vue' 
import SmartDevice from './components/SmartDevice.vue'

const userName = ref('')
const temperiture = ref(22)
const tempiwarn = ref('')
const nitemode = ref()
const selectedRoom = ref('Nappali')
const displayMessage = ref('');

const  tempcheck = () => {

  if (temperiture.value > 26) {
  
    tempiwarn.value = 'Túl meleg';
  } else {
    tempiwarn.value = '';
  }
}



</script> 
<style>
.joejt {
  background-color: black;
  color: white;
}
</style>
<template> 
<div class="app-container">


  <AppHeader /> 
  <main><h1>Smart Home Dashboard</h1></main> 
<main>

<div class="container text-center d-flex justify-content-center">

<div class="card center-box" >

  <div class="card">
  <div class="card-body">
   <label ><strong>v-model:</strong> Kívánt hőmérséglet (Cel)</label><br>
    <input @input="tempcheck" v-model="temperiture" placeholder="írj ide falamit..."> 
    {{ temperiture }} {{ tempiwarn }} <p v-if="temperiture > 26" style="color: red;"> Figyelem Túl magas a hőmérséglet </p>

  </div>
</div>
     
</div>
    <div class="card center-box"  >
      <div 
  :class="{ joejt: nitemode  }">
    <label ><strong>v-model:</strong> Éjszakai mód</label><br>
    <input v-model="nitemode" type="checkbox"> 
    {{  nitemode ? 'be': "ki" }}

     <p v-if="nitemode" > bekapcsolva </p> 
     <p v-else >ki</p>
  
    </div></div>
  <div class="card center-box" >
    <label ><strong>v-model:</strong> Felhasználó neve</label><br>
    
    <select v-model="selectedRoom" name="" id="">
      <option>Nappali</option>
  <option>Konyha</option>
  <option>Sex Dungeun</option>
    </select>

     A {{ selectedRoom }} Eszközeit látod
    </div>
 <div class="card center-box" >
  <textarea  v-model="displayMessage"></textarea>
<br>
    {{ displayMessage }}
    <br>

    {{ displayMessage.length / 50 }}
 </div>
</div>

    
  </main>

  <AppFooter /> 
  </div>
  
</template> 
