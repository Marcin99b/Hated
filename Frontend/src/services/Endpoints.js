import Api from './Api';

export default {
  users() {
    return Api().get('/api/users');
  },
};
