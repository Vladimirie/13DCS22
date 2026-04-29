<template>
  <div class="app-wrapper">
    <AppHeader />
    <main class="content">
      <aside class="side-panel">
        <LineupPanel :teamName="selectedTeamName" :teamData="selectedTeamData" />
      </aside>

      <section class="center-layout">
        <TeamTable :teams="teams" @select-team="handleSelection" />
      </section>

      <aside class="side-panel">
        <BookingForm :selectedTeam="selectedTeamName" />
      </aside>
    </main>
    <AppFooter />
  </div>
</template>

<script setup>
import { ref } from 'vue';
import AppHeader from './components/AppHeader.vue';
import AppFooter from './components/AppFooter.vue';
import TeamTable from './components/TeamTable.vue';
import BookingForm from './components/BookingForm.vue';
import LineupPanel from './components/LineupPanel.vue';

// Külső adat és a javított CSS importálása
import { teamsData } from './data/teams.js';
import './assets/main.css';

const teams = ref(teamsData);
const selectedTeamName = ref("");
const selectedTeamData = ref(null);

const handleSelection = (name) => {
  selectedTeamName.value = name;
  selectedTeamData.value = teams.value.find(t => t.name === name);
};
</script>
