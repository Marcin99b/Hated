import Vue from "vue";
import Router from "vue-router";

import MainPage from "@/views/MainPage";
import SinglePostPage from "@/views/SinglePostPage";

Vue.use(Router);

export default new Router({
  mode: "history",
  routes: [
    {
      path: "/",
      component: MainPage
    },
    {
      path: "/post/:id",
      component: SinglePostPage
    }
  ]
});
