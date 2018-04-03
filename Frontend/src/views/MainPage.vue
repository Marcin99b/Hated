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
    this.$bus.$on("closeLoginModal", () => {
      this.component = "";
      this.$refs.modal.removeAttribute("open");
    });
    this.$bus.$on("openRegisterModal", () => {
      this.component = "Register";
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
  left: 0;
  right: 0;
  width: 50vw;
  margin: 5vh auto;
}
</style>
