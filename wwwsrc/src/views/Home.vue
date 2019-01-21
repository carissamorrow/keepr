<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-12">
        <input type="text" v-model="search" class="form-control" placeholder="Search Keeps" />
        <li v-show="'search'.includes(filteredKeeps)"></li>
      </div>
      <div class="col-12">

        <h1>All Keeps Page</h1>
      </div>
    </div>
    <div class="row">
      <div class="card-columns count">
        <div v-for="keep in filteredKeeps">
          <div class="card">
            <router-link :to="{name: 'keep', params: {keepId: keep._id, keep: keep}}">
              <p class="textSpace">{{keep.name}}</p>
              <!-- <input class="form-control" type="text" v-model="keep.img" placeholder="Image URL"> -->
              <img class="imgSize" :src='keep.img'>
            </router-link>
          </div>
        </div>
      </div>
    </div>
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
          return keep.name.toLowerCase().includes(this.search.toLowerCase())
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

<style scoped>
  .home {
    background-color: lightblue;
  }

  .count {
    column-count: 4;
  }

  .card:hover {
    transform: scale(1.1);
  }
</style>