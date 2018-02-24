import Endpoints from '@/services/Endpoints';

export default {
  logIn({ commit }, user) {
    Endpoints.logIn(user)
      .then(({ data }) => {
        console.log(data);
        commit('logIn', data);
      })
      .catch((error) => {
        alert(error);
      });
  },
  register({ dispatch, commit }, user) {
    Endpoints.register(user)
      .then(({ data }) => {
        if (!data.error) {
          dispatch('logIn', user);
        } else {
          commit('registerFailed', `Użytkownik o podanych danych już istnieje`);
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
