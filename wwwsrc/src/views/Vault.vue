<template>
  <div class="vaultKeep container">
    <div class="row">
      <div class="col">
        {{vaultKeeps}}
        <div v-for="activeKeep in vaultKeeps" class="card count col-4">
          <!-- this should show all of the vaultKeeps (keeps added to this vault ) -->
          <p class="textSpace mt-3">{{keep.name}}</p>
          <p class="textSpace">{{keep.description}}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'vaultKeep',
    props: ["vaultId"],
    mounted() {
      this.$store.dispatch("getKeepsByVaultId", this.vaultId)
    },
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
    }
  }

</script>

<style>


</style>