import Endpoints from "@/services/Endpoints";

export default {
  login({ commit }, user) {
    Endpoints.login(user).then(({ data }) => {
      commit("login", data);
    });
  },
  register({ dispatch, commit }, user) {
    Endpoints.register(user).then(({ data }) => {
      if (!data.error) {
        dispatch("login", user);
      } else {
        commit("registerFailed", `Użytkownik o podanych danych już istnieje`);
      }
    });
  },
  logout({ commit }) {
    commit("logout");
  },
  checkIsAlreadyLogged({ commit }) {
    commit("checkIsAlreadyLogged");
  },
  clearError({ commit }) {
    commit("clearError");
  }
};
