<template>
  <form class="login-form" @submit.prevent="logIn">
    <div class="login-form__field">
      <label for="email">Email</label>
      <input name="email" v-model="user.email" autocomplete="current-password" type="email">
    </div>
    <div class="login-form__field">
      <label for="password">Hasło</label>
      <input name="password" autocomplete="current-password" v-model="user.password" type="password">
    </div>
    <div class="login-form__field">
      <router-link to="/register">
      Nie masz konta?
      </router-link></div>
    <div class="login-form__field">
      <button type="submit">
        Zaloguj się
      </button>
    </div>
  </form>
</template>

<script>
export default {
  data() {
    return {
      user: {
        email: 'usertest@abcd.abcd',
        password: 'testowehaslo',
      },
    };
  },
  computed: {
    currentTest() {
      return this.$store.state.test;
    },
  },
  methods: {
    logIn() {
      this.$store.dispatch('toggleTest');
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.login-form{
  width: 50vw;
  height: 50vh;
  background-color: var(--main-color);
  margin: 15vh auto 0 auto;
  display:flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  color: white;
  box-shadow: 2px 2px 5px gray;
}
.login-form__field{
  margin: 1vh 0;
}
.login-form__field input{
  border:0;
}
</style>
