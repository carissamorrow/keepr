<template>
  <div class="vaultKeep container">
    <div class="row">
      <div class="col">
        <div v-for="vaultKeep in VaultKeeps" class="card count col-4" v-show="vaultKeep.userId == user.id">
          <!-- this should show all of the vaultKeeps (keeps added to this vault ) -->
          <!-- <router-link :to="{name: 'vault', params: {vaultId: vault.id}}"> -->
          <p class="textSpace mt-3">{{vault.name}}</p>
          <p class="textSpace">{{vault.description}}</p>
          <!-- </router-link> -->
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'vaultKeep',
    data() {
      return {


      }
    },
    computed: {

    },
    methods: {

    }
  }

</script>

<style>


</style>