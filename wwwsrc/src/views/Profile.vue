<template>
  <div class="about text-center">
    {{ myBlogs }}
  </div>
</template>

<script>
export default {
  name: "Profile",
  mounted() {
    this.$store.dispatch("getMyBlogs");
  },
  computed: {
    myBlogs() {
      return this.$store.state.myBlogs;
    }
  }
};
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
