import Endpoints from '@/services/Endpoints';

export default {
    getPosts({ commit }, {from, number}){
        Endpoints.getPostsFrom(from, number)
            .then(({ data }) => {
                commit('getPosts', data);
            })
    }
}