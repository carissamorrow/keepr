<template>
  <div class="row">

    <div v-for="vault in vaults" @click="setActiveVault(vault)" class="col-3" :key="vault.id">
      <div class="card m-1">
        <router-link :to="{name: 'vault', params: {vaultId: vault.id}}">
          <h5 class="card-title">{{vault.name}}</h5>

          <i class="far fa-images fa-5x"></i>
        </router-link>
        <button class="icon" @click="deleteVault(vault)"><i class="far fa-trash-alt"></i></button>
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
    computed: {
      user() {
        return this.$store.state.user
      },
      Vaults() {
        return this.$store.state.vaults.id
      }
    },
    methods: {
      getVault(vaultId) {
        this.$store.dispatch('getvault')
      },

    },
    mounted() {
      this.$store.dispatch("getvault", this.user.id)
    },

  }
</script>

<style>
  .icon {
    cursor: pointer;
    background-color: rgba(240, 248, 255, 0);
    border-color: rgba(240, 248, 255, 0);
  }
</style>