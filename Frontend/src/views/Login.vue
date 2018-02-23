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
    <span class="error-message" v-show="error">Niepoprawny email lub hasło</span>
    <div class="login-form__field">
      <router-link to="/register">
      Nie masz konta?
      </router-link></div>
    <div class="login-form__field">
      <button type="submit" class="global-button">
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
        email: 'qwerty@qwerty.com',
        password: 'qwerty',
      },
    };
  },
  computed: {
    isLogged() {
      return this.$store.state.account.user.isLogged;
    },
    error() {
      return this.$store.state.account.loginError;
    },
  },
  methods: {
    logIn() {
      this.$store.dispatch('logIn', this.user);
      if (this.isLogged) {
        this.$router.push('/');
      }
    },
  },
  created() {
    if (this.isLogged) {
      this.$router.push('/');
    }
  },
  updated() {
    if(this.error){
      setTimeout(()=> {
        this.$store.dispatch('clearError');
      },3000);
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.login-form{
  position: absolute;
  left:0;
  right:0;
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
  text-align: center;
}
.login-form__field input{
  border:0;
  font-size: .8rem;
}
.error-message{
  font-size: 1rem;
}
@media (max-width: 1024px){
  .login-form{
    width: 80vw;
    display:flex;
    justify-content: center;
    align-items: center;
  }
  .login-form__field button{
    width: 30vw;
    padding: .3rem;
  }
  .login-form__field a{
    font-size: .9rem;
  }
}
</style>
