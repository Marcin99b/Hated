<template>
  <header class="header">
    <div class="header__heading">
      <h1>Hated</h1>
      <h2>Hejtuj jak chcesz</h2>
    </div>
    <router-link to="/" tag="img" class="header__image" src="http://via.placeholder.com/200x150" alt="Logo"></router-link>
    <router-link to="/login" tag="button" v-if="!isLogged" class="header__login">
      <span v-if="!isTouchDevice">Zaloguj się</span>
      <span v-else class="fa fa-sign-in"></span>
    </router-link>
    <div v-else class="header__login--logged">
      <button class="header__logout" @click="logOut" >Wyloguj się</button>
    </div>
  </header>
</template>

<script>
export default {
  data() {
    return {

    };
  },
  methods: {
    logOut() {
      this.$store.dispatch('logOut');
    },
  },
  computed: {
    isTouchDevice() {
      return window.innerWidth < 1024;
    },
    isLogged() {
      return this.$store.state.user.isLogged;
    },
  },
  updated() {
    if (this.isLogged) {
      this.$router.replace('/');
    }
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.header{
  position: relative;
  top:0;
  left:0;
  width: 100vw;
  height: 10vh;
  max-height: 15vh;
  display: flex;
  flex-direction:row;
  background-color: var(--main-color);
  color: white;
  box-shadow: 2px 2px 5px gray;
}
.header__image{
  position: absolute;
  left:0;
  right:0;
  margin: auto;
  height: 100%;
  padding: 1vh;
}
.header__image:hover{
  cursor: pointer;
}
.header__login,
.header__logout{
  position: absolute;
  top: 0;
  right: 0vw;
  width: 10vw;
  height: 100%;
  font-size: .9rem;
  display: flex;
  align-items: center;
  justify-content: center;
  border: 0.5vw solid transparent;
  background-color: var(--main-color);
  color:  white;
}
.header__login:hover,
.header__login:active,
.header__logout:hover,
.header__logout:active{
  cursor: pointer;
  background-color: white;
  color: var(--main-color);
}
.header__heading{
  position: absolute;
  top:0;
  left: 4vw;
  height: 100%;
  display:flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}
.header__heading h1{
  font-size: 2rem;
}
.header__heading h2{
  font-size: 1rem;
}
@media (max-width: 1024px){
  .header__login{
    width: 20vw;
  }
  .header__heading h1{
    font-size: 1.5rem;
  }
  .header__heading h2{
    font-size: 1rem;
  }
}
</style>
