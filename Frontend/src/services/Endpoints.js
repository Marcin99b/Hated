import Api from "./Api";

export default {
  async login(user) {
    return await Api().post("/Account/login", user);
  },
  async register(user) {
    return await Api().post("Account/register", user);
  },
  async newToken() {
    return await Api().post("/Account/token");
  },
  async getPostsFrom(x, y) {
    return await Api().get(`/Posts?from=${x}&number=${y}`);
  },
  async getSinglePost(postId) {
    return await Api().get(`/Posts/${postId}`);
  },
  async like({ postId, token }) {
    return await Api().post(`/Likes/post/${postId}/like`, params, {
      headers: {
        Authentication: `Bearer ${token}`
      }
    });
  },
  async unlike({ postId, token }) {
    return await Api().post(`/Likes/post/${postId}/dislike`, params, {
      headers: {
        Authentication: `Bearer ${token}`
      }
    });
  }
};
