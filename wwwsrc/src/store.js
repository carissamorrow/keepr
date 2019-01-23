import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "http://localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "http://localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    vaults: [],
    activeKeep: {},
    activeVault: [],
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setKeep(state, keep) {
      state.activeKeep = keep
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    logout(state) {
      state.user = {}
    },
    setVault(state, Vault) {
      state.vaults = Vault
    },
    setVaults(state, Vault) {
      state.vaults = Vault
    },
    setActiveKeep(state, keep) {
      state.activeKeep = keep
    },
    setActiveVault(state, activeVault) {
      state.activeVault = activeVault
    },
  },

  actions: {

    getKeepById({ commit, dispatch }, keepId) {
      api.get('keep/' + keepId)
        .then(res => {
          commit('setKeep', res.data)
        })
    },
    getVault({ commit, dispatch }) {
      api.get('vault/')
        .then(res => {
          commit('setVault', res.data)
        })
    },
    // getAllVaultsByUserId({ commit, dispatch }) {
    //   api.get('vault/' + userId)
    //     .then(res => {
    //     commit('showVaults', res.data)
    //   })
    // },

    addToVault({ commit, dispatch }, payload) {
      api.post('keep/', payload)
        .then(res => {
          console.log(res)
          dispatch('getVault')
        })
    },
    addAKeep({ commit, dispatch }, keepData) {
      api.post('keep/', keepData)
        .then(res => {
          dispatch('getAllKeeps')
        })
    },
    addAVault({ commit, dispatch }, vaultData) {
      api.post('vault/', vaultData)
        .then(res => {
          dispatch('getAllVaults')
        })
    },

    updateAKeep({ commit, dispatch }) {
      //finish this to update keeps
    },

    //get keep by Vault ID
    getKeepsByVaultId({ commit, dispatch }, vaultId) {
      api.get("keep/vault/" + vaultId)
        .then(res => {
          console.log('Keep by Vault', res.data)
          commit('setActiveKeep', res.data)
        })
    },

    deleteKeep({ commit, dispatch }, keepData) {
      api.delete('keep/' + keepData.id)
        .then(res => {
          dispatch('getKeepsByVaultId', keepData.vaultId)
          router.push({ name: 'home' })
        })
    },
    deleteVault({ commit, dispatch }, vault) {
      api.delete('vault/' + vault)
        .then(res => {
          dispatch('getAllVaults', vault)
          // router.push({ name: 'vault' })
        })
    },
    getAllKeeps({ commit, dispatch }) {
      api.get('keep/')
        .then(res => {
          console.log(res)
          commit('setKeeps', res.data)
        })
    },
    getAllVaults({ commit, dispatch }) {
      api.get('vault/')
        .then(res => {
          console.log(res)
          commit('setVaults', res.data)
        })
    },


    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          // router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }) {
      auth.delete('/logout')
        .then(res => {
          commit('setUser', {})
          // router.push({ name: 'home' })
        })
    }
  }
})