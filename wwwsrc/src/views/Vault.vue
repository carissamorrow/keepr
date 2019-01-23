<template>
  <div class="vaultKeep container">
    <div class="row">
      <div class="col">
        <div v-for="vaultKeep in vaultKeeps" class="card count col-4">
          <!-- this should show all of the vaultKeeps (keeps added to this vault ) -->
          <router-link :to="{name: 'vaultKeep', params: {vaultId: vault.id}}">
            <p class="textSpace mt-3">{{keep.name}}</p>
            <p class="textSpace">{{keep.description}}</p>
          </router-link>
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
      vaultKeeps() {
        return this.$store.state.vaultKeeps
      }
    },
    methods: {
      getKeepsByVaultId() {
        this.$store.dispatch("getKeepsByVaultId", vaultId)
      }
    }
  }

</script>

<style>


</style>