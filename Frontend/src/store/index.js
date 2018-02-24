import Vue from 'vue';
import Vuex from 'vuex';

import account from './modules/account';
import posts from './modules/posts';

Vue.use(Vuex);

export default new Vuex.Store({
  modules: {
    account,
    posts
  }
});
