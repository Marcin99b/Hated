<template>
  <div id="app">
    <Header/>
    <main>
      <router-view></router-view>
    </main>
  </div>
</template>
<script>
import Header from '@/components/Header';

export default {
  components: {
    Header,
  },
  data() {
    return {

    };
  },
};
</script>
<style>
:root{
  --main-color: rgba(179, 9, 9, 0.795);
  --main-font: 'Lato', sans-serif;
  --hand1: 'Caveat', cursive;
  --hand2: 'Kalam', cursive;
}
body {
  margin: 0;
  padding: 0;
  font-family: var(--main-font);
  font-size: 1.3rem;
}
*{
  box-sizing: border-box;
}
</style>
