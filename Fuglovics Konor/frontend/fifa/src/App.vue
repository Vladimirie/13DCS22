<script setup> 
import AppHeader from './components/AppHeader.vue' 
import AppFooter from './components/AppFooter.vue' 
</script> 
<template> 
	<AppHeader /> 
	<main>
		<div class="card">
			<h2>Team Setup</h2>
		</div>
		<div class="card">
			<h2>Team Status</h2>
		</div>
		<div class="card">
			<h2>Order tickets</h2>
			<p></p>
			<label>Name</label>
			<input type="text">
			<label>E-Mail</label>
			<input type="email">
		</div>
	</main> 
	<AppFooter /> 
</template> 
