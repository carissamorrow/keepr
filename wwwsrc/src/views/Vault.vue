<template>
  <div class="vaultKeep container">
    <div class="row">
      <div v-for="keep in vaultKeeps" class="card count col-4">
        <p class="textSpace mt-3">{{keep.name}}</p>
        <p class="textSpace">{{keep.description}}</p>
        <img class="image1 mb-2" :src="keep.img">
        <!-- <p><i class="i far fa-eye">{{keep.views}}</i>
          <i class="i fas fa-share">{{keep.shares}}</i>
          <i class="i fas fa-shopping-basket">{{keep.keeps}}</i></p> -->
        <div class="col-12">
          <button @click="deleteAVaultKeep(keep.id)" class="btn btn-lg icon mx-2"><i class="far fa-trash-alt "></i></button>
          <!-- delete by keep ID and vault ID so it only takes out of the vault -->
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
    computed: {
      vaultKeeps() {
        return this.$store.state.vaultKeeps
      },
      user() {
        return this.$store.state.user
      },

    },
    methods: {
      deleteAVaultKeep(keepId) {
        let payload = {
          vaultId: this.vaultId,
          keepId: keepId,
          userId: this.$store.state.user.id
        }
        this.$store.dispatch("deleteAVaultKeep", payload)
      }
    }
  }

</script>

<style>
  .count {
    margin-top: 5px;
    column-count: 4;
    margin-bottom: 25px;
  }

  .card:hover {
    transform: scale(1.1);
  }

  .image1 {
    max-width: 70%
  }
</style>