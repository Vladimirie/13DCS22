<script setup> 
	import {ref} from 'vue'
	import AppHeader from './components/AppHeader.vue'
	import AppFooter from './components/AppFooter.vue'
	const username = ref('')
	const temp = ref(0)
	const daynightmode = ref(false)
	const roomdata = ref([])
	/*const rooms =
	[
		{id: 1, name: "Living Room", a: #fa9},
		{id: 2, name: "Dining Room", color: #fcc},
		{id: 3, name: "Hall", color: #fb0},
		{id: 4, name: "Kitchen", color: #cca},
		{id: 5, name: "Toilet", color: #ddd},
		{id: 6, name: "Bedroom", color: #2f0},
		{id: 7, name: "Bathroom", color: #4bf}
	]*/
</script> 
<template> 
	<AppHeader /> 
	<main>
		<h1>Smart Home Dashboard</h1>
		<div class="card">
			<p><strong>v-model: </strong>User name</p>
			<input v-model="username">
			<p >Welcome, {{ username }}!</p>
		</div>
		<div class="card">
			<input type="number" v-model="temp">
			<p>Curent temp.: {{ temp }}°C</p>
			<p v-if="temp > 26" style="color:darkred"><strong>Too hot!!!</strong></p>
			<p v-if="temp < 16" style="color:blue"><strong>Too cold!!!</strong></p>
			<p v-if="temp <= -273" style="color:darkblue"><strong>Absolute Zero...</strong></p>
		</div>
		<div class="card" :style="{ backgroundColor: daynightmode ? '#000' : '#fff', color: daynightmode ? '#fff' : '#000'}">
			<input type="checkbox" v-model="daynightmode">
			<p>The light is turned {{ daynightmode ? 'off' : 'on' }}.</p>
		</div>
		<div class="card">
			<select>
				<option value="livroom">Living Room</option>
				<option value="dineroom">Dining Room</option>
				<option value="livroom"></option>
				<option value="livroom"></option>
				<option value="livroom"></option>
				<option value="livroom"></option>
				<option value="livroom"></option>
			</select>
		</div>
	</main> 
	<AppFooter /> 
</template> 
