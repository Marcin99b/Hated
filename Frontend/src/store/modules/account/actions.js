import Endpoints from '@/services/Endpoints';

export default {
  logIn({ commit }, user) {
    Endpoints.logIn(user)
      .then(({ data }) => {
        commit('logIn', data);
      })
      .catch((error) => {
        alert(error);
      });
  },
  register({ dispatch }, user) {
    Endpoints.register(user)
      .then(({ data }) => {
        if (!data.error) {
          dispatch('logIn', user);
        }
      });
  },
  logOut({ commit }) {
    commit('logOut');
  },
  checkIsAlreadyLogged({ commit }) {
    commit('checkIsAlreadyLogged');
  },
  clearError({ commit }) {
    commit('clearError');
  }
};
