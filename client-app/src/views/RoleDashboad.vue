<template>
  <div class="home">
    <!-- <errorAlert :value="error"></errorAlert> -->
    <h1 class="subtitle-1 grey--text">Role Dashboard</h1>
    <v-container class="my-5">
      <v-row class="ma-3">
         <v-tooltip top>
          <template v-slot:activator="{ on }">
            <v-btn small elevation="0" @click="sortBy('title')" v-on="on">
              <v-icon left small>folder</v-icon>
              <span right class="caption text-lowercase">by project name</span>
            </v-btn>
          </template>
          <span>Sorts projects by name</span>
        </v-tooltip>
        
        <v-tooltip top>
         <template v-slot:activator="{ on }">
            <v-btn elevation="0" small @click="sortBy('person')" v-on="on">
              <v-icon left small>person</v-icon>
              <span class="caption text-lowercase">By Person</span>
            </v-btn>
         </template>
         <span>Sorts projects by person</span>
        </v-tooltip>
       
      </v-row>
      <v-card flat class="ps-3" v-for="project in roles" :key="project.id">
        <v-row  :class="`pa-3 project ${project.status}`" >
          <v-flex xs12 md6>
            <div class="caption grey--text">ID</div>
             <div >{{project.id}}</div>
          </v-flex>
          <v-flex xs6 sm4 md2>
            <div class="caption grey--text">Name</div>
             <div >{{project.name}}</div>
          </v-flex>
        </v-row>
         <v-row cols="12">
        <v-divider></v-divider>
        </v-row>
      </v-card>
    </v-container>
  </div>
</template>

<script>
// @ is an alias to /src
import api from '../api';
// import errorAlert from '../components/ErrorAlert';
export default {
  data () {
    return {
      error:false,
      roles: []
    }
  },
  mounted() {
    api.getRoles().then(data => {
        this.error= false;
        this.roles = data.data;
        }).catch(error => {
          console.log(error);
          this.error= true;
        });
  },
  components: {
    //errorAlert
  }
  ,
  methods: {
    sortBy(prod){
      this.projects.sort((a,b)=>a[prod]<b[prod]?-1:1);
    }
  }
}
</script>
<style scoped>
.project.ongoing{
  border-left: 3px solid #3cd1c2;
}
.project.complete{
  border-left: 3px solid orange;
}
.project.overdue{
  border-left: 3px solid tomato;
}
.v-chip.ongoing{
  background:  #3cd1c2 !important;;
}
.v-chip.complete{
  background: orange !important;;
}
.v-chip.overdue{
  background:tomato !important;;
}
.v-card{
    word-break: normal;
  }
</style>>
