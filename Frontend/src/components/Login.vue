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
    <router-link to="/register">
      Nie masz konta?
    </router-link>
    <button>
      Zaloguj się
    </button>
  </form>
</template>

<script>
import Endpoints from '@/services/Endpoints';

export default {
  data() {
    return {
      user: {
        email: 'test@user@test',
        password: 'secret',
      },
    };
  },
  methods: {
    logIn() {
      Endpoints.logIn(this.user)
        .then((data) => {
          console.log(data);
        })
        .catch((error) => {
          console.log(error);
        });
    },
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.login-form{
  width: 60vw;
  height: 50vh;
}
</style>
