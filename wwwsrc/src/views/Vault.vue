<template>
  <div class="vaultKeep container">
    <div class="row">
      <div class="col owner">
        <div v-for="keep in vaultKeeps" class="card count col-4">
          <p class="textSpace mt-3">{{keep.name}}</p>
          <p class="textSpace">{{keep.description}}</p>
          <img class="imgSize mb-2" :src="keep.img">
          <p><i class="i far fa-eye">{{keep.views}}</i>
            <i class="i fas fa-share">{{keep.shares}}</i>
            <i class="i fas fa-shopping-basket">{{keep.keeps}}</i></p>
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
        return this.$store.state.keeps
      }
    },
    methods: {
    }
  }

</script>

<style>
  .owner {
    width: 60%;
  }

  .imgSize {
    width: 15vw;
    height: 20vh;

  }
</style>