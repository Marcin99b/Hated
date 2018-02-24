<template>
  <form class="register-form" @submit.prevent="register">
    <div class="register-form__field">
      <label for="username">Nazwa</label>
      <input name="username" v-model="user.username" autocomplete="honoric-prefix" type="text" :class="{correct: validateUsername, wrong: !validateUsername}">
    </div>
    <div class="register-form__field">
      <label for="email">Email</label>
      <input name="email" v-model="user.email" autocomplete="email" :class="{correct: validateEmail, wrong: !validateEmail}" type="email">
    </div>
    <div class="register-form__field">
      <label for="password">Hasło</label>
      <input name="password" autocomplete="password" v-model="user.password" type="password" :class="{correct: validatePasswords, wrong: !validatePasswords}">
    </div>
    <div class="register-form__field">
      <label for="password">Powtórz hasło</label>
      <input name="password" autocomplete="password" v-model="user.password2" type="password" :class="{correct: validatePasswords, wrong: !validatePasswords}">
    </div>
    <div class="error-box" v-if="error">
      {{error}}
    </div>
    <div class="register-form__field">
      <button type="submit" class="global-button">
        Zarejestruj się
      </button>
    </div>
  </form>
</template>

<script>
export default {
  data() {
    return {
      user: {
        email: '',
        password: '',
        password2: '',
        username: ''
      },
      TESTS: {
        username: /^[A-Za-z0-9]+(?:[ _-][A-Za-z0-9]+)*$/,
        email: /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
      }
    };
  },
  computed: {
    isLogged() {
      return this.$store.state.account.user.isLogged;
    },
    validateUsername() { 
      return this.TESTS.username.test(this.user.username);
    },
    validateEmail() { 
      return this.TESTS.email.test(this.user.email) 
    },
    validatePasswords() { 
      return this.user.password === this.user.password2 && this.user.password !== '';
    },
    validateAll() {
      return this.validateUsername && this.validateEmail && this.validatePasswords;
    },
    error(){
      return this.$store.state.account.registerError;
    }
  },
  methods: {
    register() {
      if (this.validateAll) {
        this.$store.dispatch('register', this.user);
      } else {
        alert('Błędne dane');
      }
    },
  },
  created() {
    if (this.isLogged) {
      this.$router.push('/');
    } 
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.register-form{
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
.register-form__field{
  margin: 1vh 0;
  text-align: center;
}
.register-form__field input{
  border:0;
  font-size: .8rem;
}
.error-message{
  font-size: 1rem;
}
.correct{
  background: green;
}
.wrong{
  background:red;
}
@media (max-width: 1024px){
  .register-form{
    width: 80vw;
    display:flex;
    justify-content: center;
    align-items: center;
  }
  .register-form__field button{
    width: 30vw;
    padding: .3rem;
  }
  .register-form__field a{
    font-size: .9rem;
  }
}
</style>
