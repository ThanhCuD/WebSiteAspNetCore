import Vue from 'vue'
import VueRouter from 'vue-router'
import Dashboard from '../views/Dashboard.vue'
import Team from '../views/Team.vue'
import Project from '../views/Project.vue'
import SignIn from '../views/SignIn.vue'
import store from '../store/index'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Dashboard',
    component: Dashboard
  },
  {
    path: '/team',
    name: 'Team',
    component: Team
  },
  {
    path: '/projects',
    name: 'Projects',
    component: Project
  },
  {
    path: '/signIn',
    name: 'SignIn',
    component: SignIn
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
});
// router.beforeEach((to, from, next) => {
//   console.log(store.state.auth);
//   if (!store.state.auth && to.path !== '/signIn') {
//     next({ name: 'SignIn' })
//   }
//   else next()
// })
router.beforeEach((to, from, next) => {
  if (to.name !== "Signin" && !store.state.auth) next({ name: "Signin" });
  else next();
});
export default router
