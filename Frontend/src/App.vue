<template>
  <div id="app">
    <Header/>
    <main>
      <transition name="fade">
        <router-view></router-view>
      </transition>
    </main>
  </div>
</template>
<script>
import Header from "@/components/Header";

export default {
  data() {
    return {
      timeout: null
    };
  },
  components: {
    Header
  },
  computed: {
    isLogged() {
      return this.$store.state.account.user.isLogged;
    },
    sessionExpires() {
      return this.$store.state.account.user.token.expiresInMiliseconds;
    }
  },
  mounted() {
    this.$store.dispatch("checkIsAlreadyLogged");
  },
  updated() {
    if (this.isLogged) {
      this.timeout = setTimeout(() => {
        this.$store.dispatch("logOut");
      }, this.sessionExpires);
    }
  }
};
</script>
<style>
:root {
  --main-color: rgb(154, 3, 30);
  --main-font: "Lato", sans-serif;
  --button-font-size: 0.9rem;
}
body,
html {
  margin: 0;
  padding: 0;
  font-family: var(--main-font);
  font-size: 1.3rem;
  overflow-x: hidden;
}
dialog {
  border: none;
  width: 100vw;
}
* {
  box-sizing: border-box;
}
.fade-enter-to,
.fade-leave {
  transform: scale(1);
}
.fade-enter-active,
.fade-leave-active {
  transition: transform 0.5s;
}
.fade-enter,
.fade-leave-to {
  transform: scale(0);
}
a {
  color: white;
  text-decoration: none;
}
a:focus,
a:hover {
  text-decoration: underline;
}
</style>