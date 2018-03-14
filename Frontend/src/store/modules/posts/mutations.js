export default {
  getPosts(state, posts) {
    state.posts = posts;
  },
  getSinglePost(state, post) {
    state.singlePost = post;
  }
};
