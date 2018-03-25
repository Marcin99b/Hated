import Endpoints from "@/services/Endpoints";

export default {
  async login({ commit }, user) {
    try {
      const { data } = await Endpoints.login(user);
      commit("login", data);
    } catch (error) {
      //TODO: Sensowna obsługa błędów
    }
  },
  async register({ dispatch, commit }, user) {
    try {
      const { data } = await Endpoints.register(user);
      if (!data.error) {
        dispatch("login", user);
      } else {
        commit("registerFailed", `Użytkownik o podanych danych już istnieje`);
      }
    } catch (error) {
      //TODO: Sensowna obsługa błędów
    }
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
