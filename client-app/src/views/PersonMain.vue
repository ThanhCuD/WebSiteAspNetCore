<template>
  <div class="home">
    <h1 class="subtitle-1 grey--text">Management Person</h1>
    <v-container class="my-5">
      <v-row class="ma-3">
        <v-btn @click="create">Create New Person </v-btn>
      </v-row>
      <v-card flat class="ps-3" v-for="item in person" :key="item.id">
        <v-row  :class="`pa-3 project ${item.status}`" >
          <v-flex xs6 sm4 md2>
            <div class="caption grey--text">ID</div>
             <div >{{item.id}}</div>
          </v-flex>
          <v-flex xs6 sm4 md2>
            <div class="caption grey--text">Name</div>
             <div >{{item.name}}</div>
          </v-flex>
          <v-flex xs2 sm4 md2>
            <div class="caption grey--text">Gender</div>
             <div >{{item.gender}}</div>
          </v-flex>
          <v-flex xs6 sm4 md2>
            <div class="caption grey--text">LevelInParentage</div>
             <div >{{item.levelInParentage}}</div>
          </v-flex>
          <v-flex xs6 sm4 md2>
            <div class="caption grey--text">LevelInFamily</div>
             <div >{{item.levelInFamily}}</div>
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
import api from '../api';
export default {
  components:{
  },
  data () {
    return {
      error:false,
      pageNumber: 1,
      person: []
    }
  },
  mounted() {
    this.getData();
  }
  ,
  methods: {
    getData(){
      api.getPerson(this.pageNumber).then(data => {
        this.error= false;
        this.person = data.data.data;
        console.log(data);
        }).catch(error => {
          console.log(error);
          this.error= true;
        });
    },
    create(){
      this.$router.push("/management-person/new-person");
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
