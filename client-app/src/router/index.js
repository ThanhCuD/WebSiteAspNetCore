import Vue from 'vue'
import VueRouter from 'vue-router'
import Dashboard from '../views/Dashboard.vue'
import Team from '../views/Team.vue'
import Project from '../views/Project.vue'
import SignIn from '../views/SignIn.vue'

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
})

export default router
