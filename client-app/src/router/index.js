import Vue from 'vue'
import VueRouter from 'vue-router'
import store from '../store/index'
import Dashboard from '../views/Dashboard.vue'
import Team from '../views/Team.vue'
import Project from '../views/Project.vue'
import SignIn from '../views/SignIn.vue'
import Chart from '../views/Chart.vue'
import CreateRole from '../views/CreateRole.vue'
import RoleDashboad from '../views/RoleDashboad.vue'
import PersonMain from '../views/PersonMain.vue'
import CreatePerson from '../views/Persons/CreatePerson.vue'
import DetailPerson from '../views/Persons/DetailPerson.vue'
import EditPerson from '../views/Persons/EditPerson.vue'
import api from "../api";

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
  },
  {
    path: '/createRole',
    name: 'CreateRole',
    component: CreateRole
  },
  {
    path: '/roleDashboad',
    name: 'RoleDashboad',
    component: RoleDashboad
  },
  {
    path: '/management-person',
    name: 'ManagementPerson',
    component: PersonMain
  },
  {
    path: '/management-person/new-person',
    name: 'CreatePerson',
    component: CreatePerson
  }
  ,
  {
    path: '/management-person/detail/:id',
    name: 'DetailPerson',
    component: DetailPerson
  }
  ,
  {
    path: '/management-person/update/:id',
    name: 'EditPerson',
    component: EditPerson
  },
  {
    path: '/chart',
    name: 'Chart',
    component: Chart
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
});
router.beforeEach((to, from, next) => {
  if (!store.state.auth && to.path !== '/signIn') {
    next({ name: 'SignIn' })
  }
  else{
      api.axiosInstance.defaults.headers.common[
        "Authorization"
      ] = `Bearer ${store.state.auth}`;
      next();
    }
})
export default router
