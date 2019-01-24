<template>
  <div class="home container-fluid">

    <div class="col-12">
      <input type="text" v-model="search" class="form-control class1" placeholder="Search Keeps" />
      <li v-show="'search'.includes(filteredKeeps)"></li>
    </div>
    <div class="col-12 mb-5 mt-3 banana">
      <h1>Welcome To Keepr</h1>
    </div>
    <div class="row">
      <div v-for="keep in filteredKeeps" class="card count col-4">
        <router-link :to="{name: 'keep', params: {keepId: keep.id}}">
          <p class="textSpace mt-3">{{keep.name}}</p>
          <p class="textSpace">{{keep.description}}</p>
          <img class="imgSize mb-2" :src="keep.img">
          <p><i class="i far fa-eye">{{keeps.views}}</i>
            <i class="i fas fa-share">{{keeps.shares}}</i>
            <i class="i fas fa-shopping-basket">{{keeps.keeps}}</i></p>
          <button type="button" class="btn btn-primary btn-sm">Keep</button>
          <button type="button" @click="" class="btn btn-primary btn-sm">Watch</button>
          <button type="button" class="btn btn-primary btn-sm">Share</button>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "home",
    data() {
      return {
        search: '',
        keepData: {},

        newKeep: {
          name: "",
          description: "",
          img: ""
        }
      }
    },
    // mounted() {
    //   //blocks users not logged in
    //   if (!this.$store.state.user.id) {
    //     this.$router.push({ name: "login" });
    //   }

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
      },
      // addAKeep() {
      //   this.$store.dispatch("addAKeep", this.newKeep);
      //   this.newKeep = { name: "", img: "", description: "" }
      // }
    }
  };
</script>

<style scoped>
  .count {
    margin-top: 5px;
    column-count: 4;
  }

  .card:hover {
    transform: scale(1.1);
  }

  .i {
    width: 40px
  }

  .banana {
    font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
    font-weight: bold;
  }

  .class1 {
    margin-top: 10px;
    border-color: blue;
    border-top-left-radius: 30;
  }
</style>