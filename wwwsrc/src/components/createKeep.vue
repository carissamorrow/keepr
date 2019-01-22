<template>
  <div class="postKeep">
    <form @submit.prevent="createKeep">
      <div class="form-group">
        <label for="selectedVault">Create Keep</label>
        <select class="form-control" v-model="selectedVault" id="selectedVault">
          <option v-for="vault in vaults" :key="vaultId" v-bind:value="vault">{{vault.name}}</option>
        </select>
        <input class="form-control" type="text" placeholder="Name" v-model="vaultData.name">
        <textarea class="form-control" type="text" placeholder="Description" v-model="vaultData.description"></textarea>
        <button type="submit" class="btn mt-1 btn-sm btn-danger">Create Keep</button>
      </div>
</template>

<script>
  export default {
    name: 'postKeep',
    data() {
      return {
        selectedVault: {},
        vaultData: {
          name: '',
          description: ''
        }
      }
    },
    computed: {
      vaults() {
        return this.$store.state.vaults
      },
      user() {
        return this.$store.state.user
      }
    },

    methods: {
      setActiveVault(vault) {
        this.$store.commit('setActiveVault', vault)
      },
      createKeep() {
        this.vaultData.creatorName = this.user.name
        this.vaultData.vaultName = this.selectedVault.name
        this.vaultData.vaultId = this.selectedVault.id
        this.$store.dispatch('createKeep', this.vaultData)
        this.vaultData = {
          name: '',
          description: ''
        }
      },
    }
  }

</script>

<style>


</style>