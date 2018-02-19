<template>
  <div class="hello">
    Witam
  </div>
</template>

<script>
export default {
  data() {
    return {
      users: [],
    };
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.hello{
  position: absolute;
  left:0;
  right:0;
  width: 80vw;
  min-height: 50vh;
  background: blue;
  margin: 5vh auto;
}
</style>
