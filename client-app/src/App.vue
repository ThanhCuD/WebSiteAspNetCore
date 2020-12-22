<template>
  <v-app >
    <Navbar/>
    <v-main class="grey lighten-4" >
      <div class="mx-4 mb-4">
        <router-view></router-view>
      </div>
    </v-main>
  </v-app>
</template>

<script>
import Navbar from './components/navbar'
export default {
  name: 'App',
  components: {
    Navbar
  },
  data: () => ({
    //
  }),
};
</script>
