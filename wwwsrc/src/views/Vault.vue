<template>
  <div class="vault">
    <div class="row">
      <div class="col-12">
        <form @submit.prevent="addAVault">
          <input type="text" v-model="newAlbum.name" placeholder="Name: " name="name">
          <input type="text" v-model="newAlbum.img" placeholder="Image: " name="img">
          <input type="text" v-model="newAlbum.description" placeholder="Description: " name="description">
          <button type="submit">Add A New Vault</button>
        </form>
      </div>
      <div class="col-12 mb-5 mt-3">
        <h1>All Vaults Page</h1>
      </div>
      <div class="row">
        <div class="card col-12">
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
    name: 'vault',
    data() {
      return {

      }
    },
    computed: {},
    methods: {}
  }

</script>

<style>


</style>