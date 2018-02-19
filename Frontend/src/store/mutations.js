export default {
  logIn(state, payload) {
    state.user = {
      isLogged: true,
      token: payload.data.token,
    };
  },
  logOut(state) {
    state.user = {
      isLogged: false,
      token: '',
    };
  },
};
