<template>
  <div class="vault container">
    <h1 class="mgBottom">Welcome {{user.username}}...You look lovely today</h1>
    <div class="row">
      <div class="col-12">
        <form @submit.prevent="addAVault">
          <input type="text" v-model="newVault.name" placeholder="Name: " name="name">
          <input type="text" v-model="newVault.description" placeholder="Description: " name="description">
          <button type="submit">Add A New Vault</button>
        </form>
      </div>
      <div class="col-12 mb-5 mt-3">
        <h1>All Your Vaults</h1>
      </div>
      <div class="row">
        <div v-for="vault in vaults" class="card count col-4" v-show="vault.userId == user.id">
          <router-link :to="{name: 'vault', params: {vaultId: vault.id}}">
            <p class="textSpace mt-3">{{vault.name}}</p>
            <p class="textSpace">{{vault.description}}</p>
            <img class="image1" src="http://www.hiseedschools.com/images/albums.png">
          </router-link>
          <div class="col-12">
            <button v-if="vault.userId == user.id" @click="deleteVault(vault.id)" class="btn btn-lg icon mx-2"><i class="far fa-trash-alt "></i></button>
          </div>
        </div>
      </div>
      <div class="col-12">
        <form @submit.prevent="addAKeep">
          <input type="text" v-model="newKeep.name" placeholder="Name: " name="name">
          <input type="text" v-model="newKeep.img" placeholder="Image: " name="img">
          <input type="text" v-model="newKeep.description" placeholder="Description: " name="description">
          <button type="submit">Add A New Keep</button>
        </form>
      </div>
      <div class="col-12 mb-5 mt-3">
        <h1>All Your Keeps</h1>
      </div>
      <div class="row">
        <div v-for="keep in keeps" class="card count col-4" v-show="keep.userId == user.id">
          <router-link :to="{name: 'keep', params: {keepId: keep.id}}">
            <p class="textSpace mt-3">{{keep.name}}</p>
            <p class="textSpace">{{keep.description}}</p>
            <img class="image1" :src="keep.img">
            <p><i class="far fa-eye">{{keeps.views}}</i>
              <i class="fas fa-share">{{keeps.shares}}</i>
              <i class="fas fa-shopping-basket">{{keeps.keeps}}</i></p>
          </router-link>
          <div class="col-12">
            <button v-if="keep.userId == user.id" @click="deleteKeep(keep.id)" class="btn btn-lg icon mx-2"><i class="far fa-trash-alt "></i></button>
          </div>
        </div>
      </div>

    </div>
  </div>
</template>

<script>
  export default {
    name: 'vault',
    data() {
      return {
        vaultData: {},
        // vault: [],
        newVault: {
          name: "",
          description: ""
        },
        newKeep: {
          name: "",
          description: "",
          img: ""
        },
        keepData: {},
      }
    },
    computed: {
      vault() {
        return this.$store.state.vaults
      },
      vaults() {
        return this.$store.state.vaults
      },
      user() {
        return this.$store.state.user
      },
      keeps() {
        return this.$store.state.keeps
      },
      keep() {
        return this.$store.state.keep
      }
    },
    methods: {
      addAVault() {
        this.$store.dispatch("addAVault", this.newVault);
        this.newVault = { name: "", description: "" }

      },
      deleteVault(vault) {
        this.$store.dispatch('deleteVault', vault)
      },
      deleteKeep(keep) {
        this.$store.dispatch('deleteKeep', keep)
      },
      addToVault() {
        this.$store.dispatch("addToVault", this.keep)
      },
      addAKeep() {
        this.$store.dispatch("addAKeep", this.newKeep);
        this.newKeep = { name: "", img: "", description: "" }
      }
    },
    // mounted() {
    //   if (!this.vaults.length) {
    //     this.$store.dispatch('getAllVaults')
    //   }
    // }
  }

</script>

<style>
  .count {
    margin-top: 5px;
    column-count: 3;
  }

  .card:hover {
    transform: scale(1.1);
  }

  .card {
    height: 40vh;
    width: 40vw;
    margin-bottom: 30px;
  }

  .image1 {
    width: 10vw;
    height: 20vh
  }
</style>