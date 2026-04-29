<template>
  <div class="panel-card lineup-card">
    <h3>🏃 {{ teamName || 'Csapat' }} felállása</h3>
   
    <div v-if="teamData" class="pitch-layout">
      <div class="line forwards">
        <span v-for="p in teamData.players.fw" :key="p" class="player">{{ p }}</span>
      </div>
      <div class="line midfielders">
        <span v-for="p in teamData.players.mf" :key="p" class="player">{{ p }}</span>
      </div>
      <div class="line defenders">
        <span v-for="p in teamData.players.df" :key="p" class="player">{{ p }}</span>
      </div>
      <div class="line goalkeeper">
        <span class="player gk-special">{{ teamData.players.gk }}</span>
      </div>
    </div>
   
    <div v-else class="empty-placeholder">
      <p>Válassz csapatot a felálláshoz!</p>
    </div>

    <div class="pitch-action-img">
      <img
        src="https://images.unsplash.com/photo-1517466787929-bc90951d0974?auto=format&fit=crop&q=80&w=500"
        alt="Soccer Action"
      />
    </div>
  </div>
</template>

<script setup>
defineProps(['teamData', 'teamName']);
</script>

<style scoped>
.lineup-card {
  display: flex;
  flex-direction: column;
  height: 100%;
}

.pitch-layout {
  background-color: #2d6a4f;
  background-image: linear-gradient(rgba(255,255,255,0.1) 2px, transparent 2px),
                    linear-gradient(90deg, rgba(255,255,255,0.1) 2px, transparent 2px);
  background-size: 100% 20%, 100% 100%;
  border-radius: 8px;
  padding: 10px;
  display: flex;
  flex-direction: column;
  justify-content: space-around;
  /* FIX magasság helyett flex-et használunk, hogy osztozzon a képpel */
  flex: 2;
  min-height: 250px;
  box-shadow: inset 0 0 20px rgba(0,0,0,0.3);
}

.empty-placeholder {
  flex: 2;
  display: flex;
  align-items: center;
  justify-content: center;
  background: #f3f4f6;
  border-radius: 8px;
}

.pitch-action-img {
  margin-top: 15px;
  border-radius: 8px;
  overflow: hidden;
  /* Ez veszi át a maradék helyet, de nem tolja ki a kártyát */
  flex: 1;
  min-height: 100px;
}

.pitch-action-img img {
  width: 100%;
  height: 100%;
  object-index: center;
  object-fit: cover;
}

.line { display: flex; justify-content: space-evenly; gap: 10px; width: 100%; }
.player {
  background: white;
  color: #1e3a8a;
  padding: 4px 8px;
  border-radius: 4px;
  font-size: 0.75rem;
  font-weight: bold;
  min-width: 55px;
  text-align: center;
}
.gk-special { background: #fbbf24; border-color: #d97706; }
</style>