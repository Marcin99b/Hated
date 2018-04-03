import Endpoints from "@/services/Endpoints";

export default {
  async getPosts({ commit }, { from, number }) {
    try {
      const { data } = await Endpoints.getPostsFrom(from, number);
      commit("getPosts", data);
    } catch (error) {
      //TODO: Sensowna obsługa błędów
    }
  },
  async getSinglePost({ commit }, postId) {
    try {
      const data = await Endpoints.getSinglePost(postId);
      commit("getSinglePost", data);
    } catch (error) {
      //TODO: Sensowna obsługa błędów
    }
  }
};
