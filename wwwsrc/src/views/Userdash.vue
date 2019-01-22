<template>
  <div class="userDash container">
    <h1 class="mgBottom">Welcome to your Dashboard</h1>
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
          </router-link>
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

        newVault: {
          name: "",
          description: ""
        }
      }
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      }
    },
    methods: {
      addAVault() {
        this.$store.dispatch("addAVault", this.newVault);
        this.newVault = { name: "", description: "" }
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
  }
</style>