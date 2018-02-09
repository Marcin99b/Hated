<template>
  <header class="header">
    <div class="header__heading">
      <h1>Hated</h1>
      <h2>Hejtuj jak chcesz</h2>
    </div>
    <img class="header__image" src="http://via.placeholder.com/200x150" alt="Logo">
    <div class="header__user">
      <router-link to="/login" tag="span" v-if="!isTouchDevice">Login</router-link>
      <router-link to="/login" tag="span" v-else class="fa fa-sign-in"></router-link>
    </div>
  </header>
</template>

<script>
export default {
  data() {
    return {

    };
  },
  computed: {
    isTouchDevice() {
      return window.innerWidth < 1024;
    },
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
.header__user{
  position: absolute;
  top: 0;
  right: 1vw;
  width: 8vw;
  height: 100%;
  font-size: 1.7rem;
  display: flex;
  align-items: center;
  justify-content: center;
}
.header__user:hover,
.header__user:active{
  cursor: pointer;
  background-color: white;
  color: var(--main-color);
  border: 0.5vw solid var(--main-color);
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
  .header__user{
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
