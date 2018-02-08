<template>
  <div class="hello">

  </div>
</template>

<script>
import Endpoints from '@/services/Endpoints';

export default {
  data() {
    return {
      users: [],
    };
  },
  methods: {
    fetchUsers() {
      Endpoints.users()
        .then((data) => {
          console.log(data);
        })
        .catch((error) => {
          console.error(error);
        });
    },
  },
  created() {
    this.fetchUsers();
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
