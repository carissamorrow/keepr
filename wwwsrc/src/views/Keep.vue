<template>
  <div class="keep container-fluid">

    <div class="row">
      <div class="col-12 owner">
        <p class="textSpace mt-3">{{keep.name}}</p>
        <p class="textSpace">{{keep.description}}</p>
        <img class="imgSize mb-2" :src="keep.img">
        <p><i class="i far fa-eye">{{keep.views}}</i>
          <i class="i fas fa-share">{{keep.shares}}</i>
          <i class="i fas fa-shopping-basket">{{keep.keeps}}</i></p>
      </div>
    </div>
    <div class="row">
      <div class="col-12 m-1">
        <button v-if="keep.userId == user.id" @click="deleteKeep(keepId)" class="btn btn-lg icon mx-2"><i class="far fa-trash-alt "></i></button>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <div class="dropdown" v-if="!keep.vault">
          <button class="btn btn-sm dropdown-toggle icon" type="button" id="dropdownMenuButton" data-toggle="dropdown"
            aria-haspopup="true" aria-expanded="false"><i class="fas fa-plus-circle"> </i> Add Keep to Vault
          </button>
          <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
            <p class="dropdown-item action" v-for="vault in vaults" @click="addToVault(vault.id)" :vaultData="vault"
              v-bind:value="vault.id">{{vault.name}}</p>
          </div>
        </div>
      </div>
    </div>
  </div>

</template>

<script>
  export default {
    name: 'keep',
    props: ['keepId'],
    data() {
      return {
        keepData: {},
      }
    },
    computed: {
      keep() {
        return this.$store.state.keeps.find(k => k.id == this.$route.params.keepId) || {}
        // thanks for your help on this one Mark 
      },
      vaults() {
        return this.$store.state.vaults
      },
      user() {
        return this.$store.state.user
      }
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
</script>

<style>
  .owner {
    width: 60%;
  }

  .imgSize {
    height: 40vh;
  }

  .i {
    width: 40px
  }
</style>