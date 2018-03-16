<template>
  <header class="header">
    <div class="header__heading">
      <h1>Hated</h1>
      <!-- <h2>Hejtuj jak chcesz</h2> -->
    </div>
    <router-link to="/" tag="img" class="header__image" src="http://via.placeholder.com/200x150" alt="Logo"></router-link>
    <router-link to="/login" tag="button" v-if="!user.isLogged" class="header__login global-button">
      <span v-if="!isTouchDevice">Zaloguj się</span>
      <span v-else class="fa fa-sign-in"></span>
    </router-link>
    <div v-else class="header__login--logged">
      <button class="header__logout global-button" @click="logout">
        <span v-if="!isTouchDevice">Wyloguj się</span>
        <span v-else class="fa fa-sign-out"></span> 
      </button>
    </div>
  </header>
</template>

<script>
export default {
  methods: {
    logout() {
      this.$store.dispatch("logout");
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
  background-color: var(--main-color);
  color: white;
  box-shadow: 2px 2px 5px gray;
}
.header__image {
  position: absolute;
  left: 0;
  right: 0;
  margin: auto;
  height: 100%;
  padding: 1vh;
}
.header__image:hover {
  cursor: pointer;
}
.header__login,
.header__logout {
  position: absolute;
  top: 0;
  right: 0vw;
  height: 100%;
}
.header__login:hover,
.header__login:active,
.header__logout:hover,
.header__logout:active {
  cursor: pointer;
  background-color: white;
  color: var(--main-color);
}
.header__heading {
  position: absolute;
  top: 0;
  left: 4vw;
  height: 100%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}
.header__heading h1 {
  font-size: 2rem;
}
.header__heading h2 {
  font-size: 1rem;
}
@media (max-width: 1024px) {
  .header__login,
  .header__logout {
    width: 20vw;
    font-size: 1.5rem;
  }
  .header__heading h1 {
    font-size: 1.4rem;
  }
  .header__heading h2 {
    font-size: 0.9rem;
  }
  .header__image {
    left: 10vw;
  }
}
</style>
