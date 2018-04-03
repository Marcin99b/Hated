<template>
  <article class="post">
      <div class="post__date">{{moment().format('dddd DD MMMM YYYY')}}</div>
      <div class="post__author">Autor: {{post.userId}}</div>
      <div class="post__content">Treść: {{shorterText}}</div>
      <router-link class="post__read-more" v-if="isShorter" :to="postURL">Czytaj dalej</router-link>
  </article>
</template>

<script>
export default {
  data() {
    return {
      postURL: `/post/${this.post.id}`
    };
  },
  props: {
    post: {
      type: Object,
      required: true
    },
    isShorter: {
      type: Boolean,
      required: true
    }
  },
  computed: {
    shorterText() {
      if (!this.post.content) return;
      else if (!this.isShorter) return this.post.content;
      return this.post.content
        .trim()
        .split(".")
        .slice(0, 10)
        .join(".");
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.post {
  width: 100%;
  min-height: 60vh;
  font-family: var(--hand1);
  background-image: url("https://cdn.discordapp.com/attachments/410524401986043926/416971153064722433/white-crumpled-paper-texture-for-background_1373-159.png");
  border: 2px solid var(--main-color);
  margin-bottom: 10vh;
  padding: 0.5rem;
}
.post__read-more {
  color: black;
}
</style>