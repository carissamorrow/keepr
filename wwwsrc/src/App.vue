<template>
  <div id="app">
    <div id="nav" class="mb-5">
      <nav class="navbar navbar-expand-lg navbar-light primary">
        <a class="navbar-brand" href="#"></a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
          aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          <ul class="navbar-nav mr-auto">
            <li class="nav-item">
              <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
              <a class="nav-link" href="#/userDash" v-if="userId">UserDash</a>
              <a class="nav-link" href="#" @click="logout" v-if="!userId"></a>
            </li>
          </ul>
        </div>
        <ul class="navbar-nav mr-auto px-3">
          <li class="nav-item">
            <a class="nav-link" href="#" v-if="!userId">Login/Register</a>
            <a class="nav-link" href="#" @click="logout" v-if="userId">Logout</a>
          </li>
        </ul>
      </nav>
    </div>
    <router-view />
  </div>
</template>

<script>
  export default {
    name: "app",
    data() {
      return {

      }
    },
    mounted() {
      this.$store.dispatch("getAllKeeps")
    },
    computed: {
      userId() {
        return this.$store.state.user.id
      }
    },
    methods: {
      logout() {
        Console.log("write the logout")
      }
    }
  }
</script>

<style>
  #app {
    font-family: "Avenir", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
  }

  #nav {
    padding: 30px;
  }

  #nav a {
    font-weight: bold;
    color: #2c3e50;
  }

  #nav a.router-link-exact-active {
    color: #42b983;
  }

  body {
    background-color: lightblue
  }

  .navigationbar {
    font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Oxygen, Ubuntu, Cantarell, 'Open Sans', 'Helvetica Neue', sans-serif;
    font-weight: bold
  }
</style>