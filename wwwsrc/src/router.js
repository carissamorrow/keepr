import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Keep from './views/Keep.vue'
// @ts-ignore
import Vault from './views/Vault.vue'
// @ts-ignore
import userdash from './views/userdash.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/keep/:keepId',
      name: 'keep',
      component: Keep,
      props: true
    },
    {
      path: '/vault/vaultId',
      name: 'vault',
      component: Vault,
      props: true
    },
    {
      path: '/userDash',
      name: 'userDash',
      component: userdash,
      props: true
    },
  ]
})
