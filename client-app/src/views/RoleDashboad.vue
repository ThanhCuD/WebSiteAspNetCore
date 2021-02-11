<template>
  <div class="home">
    <!-- <errorAlert :value="error"></errorAlert> -->
    <h1 class="subtitle-1 grey--text">Role Dashboard</h1>
    <v-container class="my-5">
      <v-row class="ma-3">
        <CreateRolePopup @handleIncrement="getData()"/>
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
          <v-flex xs2 sm4 md2>
                <v-btn class="info" elevation="0" dark v-on="on">Edit</v-btn>
          </v-flex>
          <v-flex xs6 sm4 md2>
            <DialogConfirm @delete="deleteItem(project.id)"/>
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
import CreateRolePopup from '../components/PopupCreateRole';
import DialogConfirm from '../components/DialogConfirm';
export default {
  components:{
    CreateRolePopup,
    DialogConfirm
  },
  data () {
    return {
      error:false,
      roles: []
    }
  },
  mounted() {
    this.getData();
  }
  ,
  methods: {
    sortBy(prod){
      this.projects.sort((a,b)=>a[prod]<b[prod]?-1:1);
    },
    getData(){
      api.getRoles().then(data => {
        this.error= false;
        this.roles = data.data.data;
        console.log(data);
        }).catch(error => {
          console.log(error);
          this.error= true;
        });
    },
    deleteItem(data){
      console.log(data);
      api.deleteRole(data).then(() => {
        this.roles = this.getData()
      }).catch(error => {
        console.log(error);
        this.error= true;
      });
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
