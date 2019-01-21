<template>
  <div class="keep container-fluid">
    <div class="row">
      <div class="col-12 m-1">
        <button v-if="keepId == userId" @click="deleteKeep(keepId)" class="btn btn-sm icon mx-2"><i class="far fa-trash-alt"></i></button>
      </div>
    </div>
    <div class="row">
      <div class="col-12 owner">
        <img class="image" :src="keep.img">
        <div class="col-12 visitor">
          <div class="dropdown" v-if="!keep.isVault">
            <button class="btn btn-sm dropdown-toggle icon" type="button" id="dropdownMenuButton" data-toggle="dropdown"
              aria-haspopup="true" aria-expanded="false"><i class="fas fa-plus-circle"> </i> Add Keep to Vault
            </button>
            <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
              <p class="dropdown-item action" v-for="vault in vaults" @click="addToVault(vaultId)" :vaultData="vault"
                v-bind:value="vaultId">{{vault.name}}</p>
            </div>
          </div>
        </div>
        <h4 class="mt-4">{{keep.name}}</h4>
        <h6 class="mb-5">{{keep.description}}</h6>
      </div>
    </div>
  </div>

</template>

<script>
  export default {
    name: 'keep',
    props: ['postId'],
    data() {
      return {
        keepData: {},
        edit: false
      }
    },
    computed: {
      keep() {
        return this.$store.state.activeKeep
      },
      Vaults() {
        return this.$store.state.Vaults
      },
      user() {
        return this.$store.state.user
      },
      methods: {
        deleteKeep() {
          this.$store.dispatch('deleteKeep', this.keep)
        },
        addToVault(keepId) {
          let payload = {
            keepId: this.keepId,
            keepData: this.keep
          }
          console.log(payload)
          this.$store.dispatch('addToVault', { payload, keepId })
        }
      },
      watch: {
        keep() {
          this.$store.dispatch('getKeepById', this.keepId)
        }
      }
    }
  }
</script>

<style>


</style>