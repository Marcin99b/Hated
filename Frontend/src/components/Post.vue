<template>
  <article class="post">
      <div class="id">Id: {{post.id}}</div>
      <div class="author">Autor: {{post.userId}}</div>
      <div class="content">Treść: {{post.content}}</div>
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
  props: ['post'],
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.post{
    width: 100%;
    min-height: 60vh;
    font-family: var(--hand1);
    background-image: url('https://cdn.discordapp.com/attachments/410524401986043926/416971153064722433/white-crumpled-paper-texture-for-background_1373-159.png');
    border: 2px solid var(--main-color);
    margin-bottom: 10vh;
    padding: .5rem;
}
</style>