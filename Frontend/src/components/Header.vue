<template>
  <header class="header">
    <router-link class="header__heading header__item" to="/" tag="h1">Hated</router-link>
    <router-link class="header__item" to="/">Strona główna</router-link>
    <router-link class="header__item" to="/poczekalnia">Poczekalnia</router-link>
    <router-link class="header__item" to="/o-nas">O Nas</router-link>
    <button v-if="!user.isLogged" @click="openLoginModal" class="header__login header__item">
      <span v-if="!isTouchDevice">Zaloguj się</span>
      <span v-else class="fa fa-sign-in"></span>
    </button>
    <button v-else class="header__logout header__item" @click="logout">
      <span v-if="!isTouchDevice">Wyloguj się</span>
      <span v-else class="fa fa-sign-out"></span> 
    </button>
  </header>
</template>

<script>
export default {
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    openLoginModal() {
      this.$bus.$emit("openLoginModal");
    }
  },
  computed: {
    isTouchDevice() {
      return window.innerWidth < 1024;
    },
    user() {
      return this.$store.state.account.user;
    }
  },
  updated() {
    if (this.user.isLogged) {
      this.$router.push("/");
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.header {
  position: relative;
  top: 0;
  left: 0;
  width: 100vw;
  height: 10vh;
  max-height: 15vh;
  display: flex;
  flex-direction: row;
  align-items: center;
  background-color: var(--main-color);
  color: white;
  box-shadow: 2px 2px 5px gray;
  font-size: 0.7rem;
}
.header__item {
  width: 11vw;
  padding: 0.6rem;
  text-align: center;
  margin: 0 0.5vw;
}
.header__item:hover:not(h1) {
  border: 2px solid white;
  border-radius: 50px;
  text-decoration: none;
}
.header__heading {
  margin-left: 0.1vw;
  margin-right: auto;
  font-size: 1.1rem;
}
.header__login {
  background-color: white;
  color: var(--main-color);
  margin-right: 2vw;
  border: none;
  border-radius: 50px;
  font-family: var(--main-font);
  font-size: 0.7rem;
  border: 2px solid transparent;
}
.header__login:hover,
.header__login:focus {
  color: white;
  background-color: var(--main-color);
  cursor: pointer;
  border: 2px solid white;
  outline: none;
}
</style>
