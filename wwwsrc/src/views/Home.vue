<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-12">
        <!-- <input type="text" v-model="search" class="form-control" placeholder="Search Keeps" />
        <li v-show="'search'.includes(filteredKeeps)"></li> -->
      </div>
      <button @click="logout">Logout</button>
    </div>
    <!-- <div class="row">
      <div class="card-columns count">
        <div v-for="keeps in filteredKeeps">
          <div class="card">
            <router-link :to="{name: 'keep', params: {keepId: keep._id, keep: keep}}">
              <img class="imgSize" :src='keep.image'>
              <p class="textSpace">{{keeps.name}}</p>
            </router-link>
          </div>
        </div>
      </div>
    </div> -->

    <h1>All Keeps Page</h1>
  </div>
</template>

<script>
  export default {
    name: "home",
    data() {
      return {
        search: ''
      }
    },
    // mounted() {
    //   //blocks users not logged in
    //   if (!this.$store.state.user.id) {
    //     this.$router.push({ name: "login" });
    //   }
    mounted() {
      this.$store.dispatch("getAllKeeps")
    },
    logout() {
      this.$store.dispatch("logout")
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      },
      filteredKeeps: function () {
        return this.keeps.filter((keep) => {
          return keep.title.toLowerCase().includes(this.search.toLowerCase())
        })
      },
    },
    methods: {
      setActiveKeep(k) {
        this.$store.commit('setKeep', k)
      }
    }
  };
</script>

<style>
  .home {
    background-color: lightblue;
  }
</style>