import actions from "./actions";
import mutations from "./mutations";

export default {
  state: {
    user: {
      isLogged: false,
      token: {
        data: "",
        expiresInMiliseconds: null
      }
    },
    loginError: "",
    registerError: ""
  },
  actions,
  mutations
};
