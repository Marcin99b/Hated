<template>
  <article class="post">
      <figure class="post__author">
        <img class="post__author-img" src="http://placehold.it/200x200" alt="">
        <figcaption class="post__author-name">Jan Kowalski</figcaption>
      <div class="post__date">
        {{moment([2018,2,12]).fromNow()}}
      </div>
      <div class="post__likes" @click="like">
        <span v-if="liked" class="fas fa-heart"></span>
        <span v-else class="far fa-heart"></span>
        <span>{{post.countLikes}}</span>
      </div>
      </figure>
      <div class="post__content">{{shorterText}}</div>
      <router-link class="post__read-more" v-if="isShorter" :to="postURL">Czytaj dalej &#8594;</router-link>
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
  height: auto;
  width: 100%;
  font-family: var(--main-font);
  background-color: #FFFFFF;
  box-sizing: border-box;
  padding: 15px 30px;
  margin-bottom: 2vw;
  border-radius: 8px;
  box-shadow: 0px 0px 0.5px 0px rgba(71, 70, 70, 0.918);
}
.post__read-more {
  color: black;
}
.post__author {
  display: flex;
  justify-content: flex-start;
  align-items: stretch;
  margin-bottom: 28px;
}
.post__author-img {
  height: 50px;
  width: auto;
  border-radius: 100%;
  margin-right: 10px;
}
.post__author-name {
  font-size: 14px;
  font-weight: bold;
  margin-top: 12px;
  position: relative;
}
.post__author-name::after {
  position: absolute;
  top: -3px;
  right: -15px;
  content: "";
  background-color: #F6F6F6;
  width: 2px;
  height: 18px;
  display: inline-block;
}
.post__date {
  font-size: 14px;
  margin-top: 10px;
  margin-left: 30px;
  position: relative;
}
.post__date::after {
  position: absolute;
  top: -3px;
  right: -15px;
  content: "";
  background-color: #F6F6F6;
  width: 2px;
  height: 18px;
  display: inline-block;
}
.post__likes {
  font-size: 14px;
  margin-top: 10px;
  margin-left: 30px;
  cursor: pointer;
}
.post__content {
  font-size: 0.45em;
  line-height: 14px;
  margin-bottom: 20px;
}
.post__read-more {
  font-size: 16px;
}
</style>