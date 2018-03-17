import Vue from "vue";
import Router from "vue-router";

import MainPage from "@/views/MainPage";
import LoginPage from "@/views/LoginPage";
import RegisterPage from "@/views/RegisterPage";
import SinglePost from "@/views/SinglePost";

Vue.use(Router);

export default new Router({
  mode: "history",
  routes: [
    {
      path: "/",
      component: MainPage
    },
    {
      path: "/login",
      component: LoginPage
    },
    {
      path: "/register",
      component: RegisterPage
    },
    {
      path: "/post/:id",
      component: SinglePost
    }
  ]
});
