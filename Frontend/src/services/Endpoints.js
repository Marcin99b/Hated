import Api from './Api';

export default {
  logIn(user) {
    return Api().post('/Account/login', user);
  },
};
