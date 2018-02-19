import Vue from 'vue';
import Router from 'vue-router';

import Main from '@/views/Main';
import Login from '@/views/Login';
import Register from '@/views/Register';

Vue.use(Router);

export default new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      component: Main,
    },
    {
      path: '/login',
      component: Login,
    },
    {
      path: '/register',
      component: Register,
    },
  ],
});
