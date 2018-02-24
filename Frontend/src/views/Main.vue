<template>
  <article class="posts">
    <Post v-for="(post, index) in posts" :key="index" :post="post"/>
  </article>
</template>

<script>
import Post from '@/components/Post';

export default {
  data() {
    return {
      
    };
  },
  computed:{
    posts(){
      return this.$store.state.posts.posts;
    }
  },
  created(){
    this.$store.dispatch('getPosts', {
      from: 0,
      number: 10
    });
  },
  components: {
    Post,
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.posts{
  position: absolute;
  left:0;
  right:0;
  width: 50vw;
  margin: 5vh auto;
}
</style>
