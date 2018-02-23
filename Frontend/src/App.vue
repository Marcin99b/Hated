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
import Header from '@/components/Header';

export default {
  components: {
    Header,
  },
  mounted() {
    this.$store.dispatch('checkIsAlreadyLogged');
  },
};
</script>
<style>
:root{
  --main-color: rgba(179, 9, 9, 0.795);
  --main-font: 'Lato', sans-serif;
  --button-font-size: .9rem;
  --hand1: 'Caveat', cursive;
  --hand2: 'Kalam', cursive;
}
body, html {
  margin: 0;
  padding: 0;
  font-family: var(--main-font);
  font-size: 1.3rem;
}
.global-button{
  width: 10vw;
  font-size: .9rem;
  display: flex;
  align-items: center;
  justify-content: center;
  border: 0.5vw solid transparent;
  background-color: var(--main-color);
  color:  white;
}
.global-button:hover{
  color: var(--main-color);
  background-color: white;
  cursor: pointer;
}
*{
  box-sizing: border-box;
}
.fade-enter-to, .fade-leave{
  transform: scale(1);
}
.fade-enter-active, .fade-leave-active {
  transition: transform .5s;
}
.fade-enter, .fade-leave-to {
  transform: scale(0);
}
a{
  color: white;
  text-decoration: none;
}
a:focus,
a:hover{
  text-decoration:underline;
}
</style>