<template>
  <header class="header">
    <img class="header__image" src="http://via.placeholder.com/200x150" alt="Logo">
    <div class="header__user">
      <span v-if="!isTouchDevice">Login</span>
      <span v-else class="fa fa-sign-in"></span>
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
@media (max-width: 1024px){
  .header__user{
    right: 5vw;
  }
}
</style>
