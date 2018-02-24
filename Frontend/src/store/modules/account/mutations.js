import SessionStorageHandler from '../../sessionStorage';

export default {
  logIn(state, payload) {
    if (payload.token) {
      state.user = {
        isLogged: true,
        token: payload.token,
      };
      SessionStorageHandler.saveState(state);
    } else {
      state.loginError = payload.error;
    }
  },
  registerFailed(state, error){
    state.registerError = error;
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
  clearError(state) {
    state.loginError = null;
    state.registerError = null;
  }
};
