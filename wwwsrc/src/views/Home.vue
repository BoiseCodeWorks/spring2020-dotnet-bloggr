<template>
  <div class="home">
    <img alt="Vue logo" src="../assets/logo.png" />
    <h1>Welcome to Your Vue.js App</h1>
    {{ blogs }}
  </div>
</template>

<script>
export default {
  name: "home",
  computed: {
    blogs() {
      return this.$store.state.publicBlogs;
    }
  }
};
</script>
