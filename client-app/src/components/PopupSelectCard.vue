<template>
  <div class="text-center">
    <v-dialog width="500" v-model="dialog">
      <template v-slot:activator="{ on }">
        <v-btn class="success" dark v-on="on">Select Parent</v-btn>
      </template>
       <v-card>
        <v-card-title class="headline grey lighten-2" primary-title>Select Parent</v-card-title>
        <v-card-text>
          <v-row>
        <v-flex xs12 sm6 md4 lg3 v-for="person in data" :key="person.id">
          <v-card class="text-center ma-3">
            <v-responsive class="pt-5">
              <v-avatar size="100" class="lighten-2">
              <v-img :src="person.img"></v-img>
            </v-avatar>
            </v-responsive>
            <v-card-text>
              <div class="subheading">{{person.name}}</div>
              <div class="grey--text">{{person.role}}</div>
            </v-card-text>
            <v-card-actions class="text-center">
                <v-btn elevation="0"  color="white">
                  <span
                  @click="select(person.id)"
                  >Select</span>
                </v-btn>
            </v-card-actions>
          </v-card>
        </v-flex>
      </v-row>
        </v-card-text>
      </v-card>
    </v-dialog>
  </div>
</template>
<script>
import format from 'date-fns/format';
import parseISO from 'date-fns/parseISO';
import api from '../api';
export default {
  data(){
    return {
      title:'',
      info:'',
      due: '',
      pageNumber: 1,
      inputRules: [
        v=>v.length>=3 || "Minimmum length = 3"
      ],
      data: [
        { id :  1, name: 'The Net Ninja', role: 'Web developer', img :'/avatar-1.png' },
        { id :  2,name: 'Ryu', role: 'Graphic designer' ,img :'/avatar-2.png'},
        { id :  3,name: 'Chun Li', role: 'Web developer' ,img :'/avatar-3.png'},
        { id :  4,name: 'Gouken', role: 'Social media maverick' ,img :'/avatar-4.png'},
        { id :  5,name: 'Yoshi', role: 'Sales guru',img :'/avatar-5.png'}
      ],
      dialog : false,
      loading: false
    }
  },
  mounted(){
    this.loadData();
  },
  methods: {
    select(id){
      this.$emit('selected',id);
      this.dialog = false;
    },
    loadData(){
      api.getPersons(this.pageNumber).then(data => {
        this.error= false;
        this.data = data.data.data;
        console.log(data);
        
        }).catch(errors=>{
          console.log(errors);
          this.error= true;
          if (errors.response.status === 401 && errors.response.headers["token-expired"]) {
              this.$router.push("/signIn");
          }
        });
    }
  },
  computed: {
    formatDat(){
      return this.due? format(parseISO(this.due), 'do MMM yyyy') : '';
    }
  }
}
</script>