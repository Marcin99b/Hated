<template>
  <article class="post">
      <div class="post__id">Id: {{post.id}}</div>
      <div class="post__author">Autor: {{post.userId}}</div>
      <div class="post__content">Treść: {{post.content | shorterText}}</div>
      <router-link class="post__read-more" :to="postURL">Czytaj dalej</router-link>
      <br><br> Komentarze <br><br>
      <ul>
          <li v-for="(comment, index) in post.comments" :key="index">
              Id: {{comment.id}}
              Autor: {{comment.userId}}
              Treść: {{comment.content}}
          </li>
      </ul>
  </article>
</template>

<script>
export default {
  data() {
    return {
      postURL: `/post/${this.post.id}`
    };
  },
  props: ["post"],
  filters: {
    shorterText(value) {
      if (!value) return "Brak treści";
      return value
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