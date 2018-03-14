import Endpoints from "@/services/Endpoints";

export default {
  getPosts({ commit }, { from, number }) {
    Endpoints.getPostsFrom(from, number).then(({ data }) => {
      commit("getPosts", data);
    });
  },
  getSinglePost({ commit }, postId) {
    Endpoints.getSinglePost(postId).then(({ data }) => {
      commit("getSinglePost", data);
    });
  }
};
