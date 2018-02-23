import actions from './actions';
import mutations from './mutations';
import getters from './getters';

export default {
    state: {
        user: {
            isLogged: false,
            token: '',
        },
        loginError: ''
    },
    actions,
    mutations
}