<template>
  <div>
    <dialog ref="modal">
      <component :is="component"/>
    </dialog>  
    <article class="posts">
      <Post v-for="(post, index) in posts" :key="index" :post="post" :isShorter="isShorter"/>
    </article>
    <nav class="pagination">
      <!-- TODO: Paginacja strony głównej -->
    </nav>
  </div>
</template>

<script>
import Post from "@/components/Post";
import Register from "@/components/Register";
import Login from "@/components/Login";

export default {
  data() {
    return {
      isShorter: true,
      component: "Login"
    };
  },
  computed: {
    posts() {
      return this.$store.state.posts.posts;
    }
  },
  created() {
    this.$store.dispatch("getPosts", {
      from: 0,
      number: 10
    });
    this.$bus.$on("openLoginModal", () => {
      this.component = "Login";
      this.$refs.modal.setAttribute("open", "");
    });
  },
  components: {
    Post,
    Register,
    Login
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.posts {
  position: absolute;
  left: 50%;
  transform: translateX(-50%);
  width: 50%;
  box-sizing: border-box;
  padding: 40px 70px;
  background-color: #f6f6f6;
}
</style>
