<template>
  <article class="post">
      {{post.id}}
      <figure class="post__author">
        <img src="http://placehold.it/200x200" alt="">
        <figcaption>{{ post.author.username }}</figcaption>
      </figure>
      <div class="post__date">
        {{moment([2018,2,12]).fromNow()}}
      </div>
      <div class="post__likes" @click="like">
          <span v-if="liked" class="fas fa-heart"></span>
          <span v-else class="far fa-heart"></span>
          <span>{{post.countLikes}}</span>
      </div>
      <div class="post__content">{{shorterText}}</div>
      <router-link class="post__read-more" v-if="isShorter" :to="postURL">Czytaj dalej</router-link>
  </article>
</template>

<script>
export default {
  data() {
    return {
      postURL: `/post/${this.post.id}`,
      liked: false
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
    },
    token() {
      return this.$store.state.account.user.token.data;
    }
  },
  methods: {
    like() {
      if (!this.liked) {
        console.log(this.token);
        this.$store.dispatch("like", {
          postId: this.post.id,
          token: this.token
        });
        this.post.countLikes++;
      } else {
        this.$store.dispatch("unlike", {
          postId: this.post.id,
          token: this.token
        });
        this.post.countLikes--;
      }
      this.liked = !this.liked;
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.fa-heart {
  color: var(--main-color);
}
.post {
  position: relative;
  z-index: 0;
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