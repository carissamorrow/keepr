<template>
  <div class="userDash container">
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
        <div v-for="vault in vaults" class="card count col-4">
          <router-link :to="{name: 'vault', params: {vaultId: vault.id}}">
            <p class="textSpace mt-3">{{vault.name}}</p>
            <p class="textSpace">{{vault.description}}</p>
            <img class="image1" src="http://www.hiseedschools.com/images/albums.png">
          </router-link>
          <div class="col-12">
            <button v-if="vault.userId == user.id" @click="deleteVault(vaultId)" class="btn btn-lg icon mx-2"><i class="far fa-trash-alt "></i></button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'userDash',
    data() {
      return {
        vaultData: {},
        // vault: [],
        newVault: {
          name: "",
          description: ""
        }
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
      }
    },
    methods: {
      addAVault() {
        this.$store.dispatch("addAVault", this.newVault);
        this.newVault = { name: "", description: "" }

      },
      deleteVault() {
        this.$store.dispatch('deleteVault', this.vaultId)
      },
    },
    mounted() {
      if (!this.vaults.length) {
        this.$store.dispatch('getAllVaults', this.vaults)
      }
    }
  }

</script>

<style>
  .count {
    margin-top: 5px;
    column-count: 4;
  }

  .card:hover {
    transform: scale(1.1);
  }

  .card {
    height: 40vh;
    margin-bottom: 30px;
  }

  .image1 {
    width: 10vw;
    height: 20vh
  }
</style>