import { createRouter, createWebHistory } from 'vue-router'


import cica from '../cica.vue';
import List from '../list.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {path: '/list', component: List},
    {path: '/', component: cica}
  ],
})

export default router
