<template>
  <div class="section form-box">
    <div class="form-header">
      <h2>🎟️ Meccsjegy foglalás</h2>
      <div v-if="selectedTeam" class="selected-badge">
        Kiválasztott csapat: <span>{{ selectedTeam }}</span>
      </div>
      <div v-else class="warning-badge">
        Kérjük, válassz csapatot a táblázatban!
      </div>
    </div>

    <form @submit.prevent="submitBooking" class="styled-form">
      <div class="input-group">
        <label>Teljes név</label>
        <input
          v-model="formData.name"
          type="text"
          placeholder="Pl.: Kovács János"
          required
        />
      </div>

      <div class="input-group">
        <label>Email cím</label>
        <input
          v-model="formData.email"
          type="email"
          placeholder="pelda@email.com"
          required
        />
      </div>
     
      <button :disabled="isLoading || !selectedTeam" type="submit" class="submit-btn">
        <span v-if="!isLoading">Jegy igénylése</span>
        <span v-else class="loader-text">
          <span class="spinner">⏳</span> Feldolgozás...
        </span>
      </button>
    </form>
    <div class="promo-image">
      <img src="https://www.vancouverisawesome.com/static/assets/stadium-icon.jpg"
           onerror="this.src='https://cdn-icons-png.flaticon.com/512/1165/1165187.png'"
           alt="Stadium" />
   
  </div>
  </div>
</template>

<script setup>
import { reactive, ref } from 'vue';

const props = defineProps(['selectedTeam']);
const isLoading = ref(false);

const formData = reactive({
  name: '',
  email: ''
});

const submitBooking = async () => {
  isLoading.value = true;

  // Szimulált hálózati késleltetés (2 másodperc)
  await new Promise(resolve => setTimeout(resolve, 2000));

  alert(`Sikeres foglalás!\nNév: ${formData.name}\nCsapat: ${props.selectedTeam}`);
 
  isLoading.value = false;
  formData.name = '';
  formData.email = '';
};
</script>

<style scoped>
.form-box {
  background: white;
  border-radius: 12px;
  border: 2px solid #e5e7eb;
  padding: 2rem;
  box-shadow: 0 10px 15px -3px rgba(0, 0, 0, 0.1);
  max-width: 600px;
  margin: 0;
  height:100%;
}

.form-header {
  text-align: center;
  margin-bottom: 2rem;
}

h2 {
  color: #1e3a8a;
  margin-bottom: 1rem;
}

.selected-badge {
  background-color: #dbeafe;
  color: #1e40af;
  padding: 0.5rem 1rem;
  border-radius: 8px;
  display: inline-block;
  font-weight: 600;
}

.selected-badge span {
  color: #2563eb;
  text-transform: uppercase;
}

.warning-badge {
  color: #dc2626;
  font-style: italic;
  font-size: 0.9rem;
}

.styled-form {
  display: flex;
  flex-direction: column;
  gap: 1.5rem;
}

.input-group {
  display: flex;
  flex-direction: column;
  gap: 0.5rem;
}

.input-group label {
  font-size: 0.9rem;
  font-weight: 600;
  color: #4b5563;
}

input {
  padding: 0.75rem;
  border: 2px solid #e5e7eb;
  border-radius: 8px;
  font-size: 1rem;
  transition: all 0.3s ease;
}

input:focus {
  outline: none;
  border-color: #3b82f6;
  box-shadow: 0 0 0 3px rgba(59, 130, 246, 0.1);
}

.submit-btn {
  background: linear-gradient(135deg, #1e3a8a 0%, #3b82f6 100%);
  color: white;
  padding: 1rem;
  border: none;
  border-radius: 8px;
  font-size: 1.1rem;
  font-weight: bold;
  cursor: pointer;
  transition: transform 0.2s, opacity 0.2s;
  margin-top: 1rem;
}

.submit-btn:hover:not(:disabled) {
  transform: translateY(-2px);
  box-shadow: 0 4px 12px rgba(37, 99, 235, 0.3);
}

.submit-btn:disabled {
  background: #9ca3af;
  cursor: not-allowed;
  opacity: 0.7;
}

.loader-text {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 10px;
}

.spinner {
  animation: rotate 2s linear infinite;
}

@keyframes rotate {
  from { transform: rotate(0deg); }
  to { transform: rotate(360deg); }
}
.promo-image {
  margin-top: 2rem;
  border-radius: 8px;
  overflow: hidden;
  height: 150px;
}
.promo-image img {
  width: 100%;
  height: 100%;
  object-fit: cover;
}
</style>
