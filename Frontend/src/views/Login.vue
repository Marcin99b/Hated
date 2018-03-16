<template>
  <form class="login-form" @submit.prevent="login">
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
    <div v-if="loading" class="login-form__field spinner">
      <div class="rect1"></div>
      <div class="rect2"></div>
      <div class="rect3"></div>
      <div class="rect4"></div>
      <div class="rect5"></div>
    </div>
  </form>
</template>

<script>
export default {
  data() {
    return {
      user: {
        email: "qwerty@qwerty.com",
        password: "qwerty"
      },
      loading: false
    };
  },
  computed: {
    isLogged() {
      return this.$store.state.account.user.isLogged;
    },
    error() {
      return this.$store.state.account.loginError;
    }
  },
  methods: {
    login() {
      this.loading = true;
      this.$store.dispatch("login", this.user);
    }
  },
  created() {
    if (this.isLogged) {
      this.$router.push("/");
    }
  },
  updated() {
    if (this.error) {
      this.loading = false;
      setTimeout(() => {
        this.$store.dispatch("clearError");
      }, 3000);
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.login-form {
  position: absolute;
  left: 0;
  right: 0;
  width: 50vw;
  height: 50vh;
  background-color: var(--main-color);
  margin: 15vh auto 0 auto;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  color: white;
  box-shadow: 2px 2px 5px gray;
}
.login-form__field {
  margin: 1vh 0;
  text-align: center;
}
.login-form__field input {
  border: 0;
  font-size: 0.8rem;
}
.error-message {
  font-size: 1rem;
}
/* Spinner */
.spinner {
  margin: 0 auto;
  width: 50px;
  height: 40px;
  text-align: center;
  font-size: 10px;
}

.spinner > div {
  background-color: var(--main-color);
  height: 100%;
  width: 6px;
  display: inline-block;

  -webkit-animation: sk-stretchdelay 1.2s infinite ease-in-out;
  animation: sk-stretchdelay 1.2s infinite ease-in-out;
}

.spinner .rect2 {
  -webkit-animation-delay: -1.1s;
  animation-delay: -1.1s;
}

.spinner .rect3 {
  -webkit-animation-delay: -1s;
  animation-delay: -1s;
}

.spinner .rect4 {
  -webkit-animation-delay: -0.9s;
  animation-delay: -0.9s;
}

.spinner .rect5 {
  -webkit-animation-delay: -0.8s;
  animation-delay: -0.8s;
}

@-webkit-keyframes sk-stretchdelay {
  0%,
  40%,
  100% {
    -webkit-transform: scaleY(0.4);
  }
  20% {
    -webkit-transform: scaleY(1);
  }
}

@keyframes sk-stretchdelay {
  0%,
  40%,
  100% {
    transform: scaleY(0.4);
    -webkit-transform: scaleY(0.4);
  }
  20% {
    transform: scaleY(1);
    -webkit-transform: scaleY(1);
  }
}
/*Spinner end*/
@media (max-width: 1024px) {
  .login-form {
    width: 80vw;
    display: flex;
    justify-content: center;
    align-items: center;
  }
  .login-form__field button {
    width: 30vw;
    padding: 0.3rem;
  }
  .login-form__field a {
    font-size: 0.9rem;
  }
}
</style>
