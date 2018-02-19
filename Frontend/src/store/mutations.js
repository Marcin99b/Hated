import SessionStorageHandler from './sessionStorage';

export default {
  logIn(state, payload) {
    if (payload.token) {
      state.user = {
        isLogged: true,
        token: payload.token,
      };
      SessionStorageHandler.saveState(state);
    } else {
      state.loginError = payload.errorMessage;
    }
  },
  logOut(state) {
    state.user = {
      isLogged: false,
      token: '',
    };
    SessionStorageHandler.removeState();
  },
  checkIsAlreadyLogged(state) {
    if (SessionStorageHandler.isLogged()) {
      const newState = SessionStorageHandler.getState();
      state.user = newState.user;
    }
  },
};
