<template>
  <div class="home container-fluid">
    <div class="row">
      <div class="col-12">
        <input type="text" v-model="search" class="form-control" placeholder="Search Keeps" />
        <li v-show="'search'.includes(filteredKeeps)"></li>
      </div>
      <div class="col-12 mb-5 mt-3">
        <h1>All Keeps Page</h1>
      </div>
    </div>
    <div class="row">
      <div class="card-columns count col-12">
        <div v-for="keep in filteredKeeps">
          <div class="card">
            <router-link :to="{name: 'keep', params: {keepId: keep.id}}">
              <p class="textSpace mt-3">{{keep.name}}</p>
              <p class="textSpace">{{keep.description}}</p>
              <img class="imgSize mb-2" :src="keep.img">
              <p><i class="far fa-eye">{{keeps.views}}</i>
                <i class="fas fa-share">{{keeps.shares}}</i>
                <i class="fas fa-shopping-basket">{{keeps.keeps}}</i></p>
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

  .card {
    height: 50vh;
  }

  .imgSize {
    height: 23vh;
  }

  i {
    width: 30px
  }
</style>