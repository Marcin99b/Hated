import Api from "./Api";

export default {
  logIn(user) {
    return Api().post("/Account/login", user);
  },
  register(user) {
    return Api().post("Account/register", user);
  },
  newToken() {
    return Api().post("/Account/token");
  },
  getPostsFrom(x, y) {
    return Api().get(`/Posts?from=${x}&number=${y}`);
  },
  getSinglePost(postId) {
    return Api().get(`/Posts/${postId}`);
  }
};
