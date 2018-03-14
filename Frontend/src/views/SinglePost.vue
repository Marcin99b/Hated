<template>
  <Post :post="post" isShorter="false"/>
</template>

<script>
import Post from "@/components/Post";

export default {
  data() {
    return {
      postId: this.$route.params.id
    };
  },
  computed: {
    post() {
      return this.$store.state.posts.singlePost;
    }
  },
  components: {
    Post
  },
  created() {
    this.$store.dispatch("getSinglePost", this.postId);
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>