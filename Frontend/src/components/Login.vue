<template>
<div class="login_container">
  <form class="login-form" @submit.prevent>
    <button @click="closeLoginModal()" class="login-form-close">X</button>
    <div class="login-form__field">
      <input placeholder="E-mail" name="email" v-model="user.email" autocomplete="current-password" type="email">
    </div>
    <div class="login-form__field">
      <input placeholder="Hasło" name="password" autocomplete="current-password" v-model="user.password" type="password">
    </div>
    <div class="login-form__field">
      <button @click="login()" type="submit" class="global-button">
        Zaloguj się
      </button>
    </div>
    <span class="error-message" v-show="error">Niepoprawny email lub hasło</span>
    <div class="login-form__field register">
      <router-link to="/register">
      Nie posiadasz konta? <span>Zarejestruj się!</span>
      </router-link>
    </div>
    <div v-if="loading" class="login-form__field spinner">
      <div class="rect1"></div>
      <div class="rect2"></div>
      <div class="rect3"></div>
      <div class="rect4"></div>
      <div class="rect5"></div>
    </div>
  </form>
</div>
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
    },
    closeLoginModal() {
      this.$bus.$emit("closeLoginModal");
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
.login_container {
  position: fixed;
  top: 0;
  left: 0;
  height: 100%;
  width: 100%;
  background-color: rgba(0,0,0,0.51);
  z-index: 9999;
}
.login-form {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%,-50%);
  background-color: #FFFFFF;
  max-width: 480px;
  width: 100%;
  padding: 30px 0 35px 20px;
  border-radius: 5px;
}
.login-form__field {
  margin: 1vh 0;
  text-align: center;
}
.login-form__field input {
  border: 0;
  font-size: 0.8rem;
  text-align: center;
  background-color: #f6f6f6;
  box-sizing: border-box;
  padding: 13px 0;
  width: 100%;
  max-width: 250px;
  margin-bottom: 8px;
  border-radius: 10px;
  outline: none;
}
.login-form__field button {
  background-color: #9a031e;
  color: #FFFFFF;
  width: 100%;
  max-width: 250px;
  border: none;
  cursor: pointer;
  padding: 13px 0;
  border-radius: 10px;
  margin-bottom: 25px;
}
.error-message {
  font-size: 1rem;
  display: flex;
  justify-content: center;
  margin-bottom: 30px;
}
.register > a {
  color: #c5b5b5;
  font-size: 12px;
}
.register > a > span {
  color: #9a031e;
  margin-left: 10px;
}
.login-form-close {
  position: absolute;
  top: 10px;
  right: 10px;
  height: 32px;
  cursor: pointer;
  width: 32px;
  border-radius: 100%;
  border: 1px solid #dfdfdf;
  background-color: #FFFFFF;
  color: #dfdfdf;
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
