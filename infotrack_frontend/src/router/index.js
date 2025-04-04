import { createRouter, createWebHistory } from "vue-router";
import SearchView from "../views/SearchView.vue";
import HistoryView from "@/views/HistoryView.vue";

const routes = [
  {
    path: "/",
    name: "search",
    component: SearchView,
  },
  {
    path: "/history",
    name: "history",
    component: HistoryView,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
