<template>
  <div class="table-card">
    <h2>Csoportkör állása</h2>
    <div class="scroll-container">
      <table>
        <thead>
          <tr>
            <th>Zászló</th>
            <th>Ország</th>
            <th>Pont</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="team in teams" :key="team.id" :class="{ 'active-row': activeId === team.id }"
            @click="handleSelect(team)">
            <td class="flag-cell">
              <div class="selection-indicator"></div>
              <img :src="team.flag" :alt="team.name" class="flag" />
            </td>
            <td class="name">{{ team.name }}</td>
            <td class="pts">{{ team.points }}</td>
          </tr>
        </tbody>
      </table>
    </div>

    <div class="table-decoration">
      <img src="https://images.unsplash.com/photo-1574629810360-7efbbe195018?auto=format&fit=crop&q=80&w=500" alt="World Cup Stadium" />
    </div>
    <p><strong>"Éld át a győzelem ízét! A 2026-os VB minden pillanata tartogat egy újabb legendát. Kövesd élőben a csoportkör izgalmait!"</strong></p>
  </div>
</template>

<script setup>
  import { ref } from 'vue';
  const props = defineProps(['teams']);
  const emit = defineEmits(['select-team']);

  const activeId = ref(null);

  const handleSelect = (team) => {
    activeId.value = team.id;
    emit('select-team', team.name);
  };
</script>

<style scoped>
  .table-card {
    background: white;
    border-radius: 12px;
    padding: 15px;
    box-shadow: 0 4px 15px rgba(0, 0, 0, 0.2);
    height: 100%;
    display: flex;
    flex-direction: column; /* Függőleges elrendezés */
  }

  .scroll-container {
    flex: 1; /* Ez engedi, hogy a táblázat kitöltse a helyet, de ne tolja el a képet */
    max-height: 350px;
    overflow-y: auto;
    border: 1px solid #eee;
    border-radius: 8px;
    margin-bottom: 15px;
  }

  /* Kép javítása, hogy ne lógjon ki */
  .table-decoration {
    width: 100%;
    height: 120px; /* Fix magasság a képnek */
    border-radius: 8px;
    overflow: hidden;
    background: #f8fafc;
  }

  .table-decoration img {
    width: 100%;
    height: 100%;
    object-fit: cover; /* Kitölti a helyet torzítás nélkül */
    display: block;
  }

  table {
    width: 100%;
    border-collapse: collapse;
  }

  /* ... A többi stílusod (thead, tr, td, stb.) változatlan maradhat ... */
  thead {
    position: sticky;
    top: 0;
    background: #1e3a8a;
    color: white;
    z-index: 10;
  }

  th {
    padding: 12px;
    text-align: left;
    font-size: 0.8rem;
  }

  tr {
    cursor: pointer;
    transition: background 0.2s;
    position: relative;
  }

  tr:hover {
    background-color: #f1f5f9 !important;
  }

  td {
    padding: 12px;
    border-bottom: 1px solid #f1f5f9;
    color: #333;
  }

  .flag-cell {
    display: flex;
    align-items: center;
    gap: 10px;
  }

  .selection-indicator {
    position: absolute;
    left: 0;
    top: 0;
    bottom: 0;
    width: 4px;
    background-color: transparent;
  }

  .active-row {
    background-color: #e0f2fe !important;
  }

  .active-row .selection-indicator {
    background-color: #3b82f6;
  }

  .flag {
    width: 25px;
    border-radius: 2px;
  }

  .name {
    font-weight: 600;
  }

  .pts {
    font-weight: 800;
    color: #1e3a8a;
    text-align: right;
  }
</style>
