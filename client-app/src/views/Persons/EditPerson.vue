<template>
<v-container class="my-5">
<errorAlert :value="error"></errorAlert>
  <v-form
    ref="form"
    v-model="valid"
    lazy-validation
  >
    <v-text-field
      v-model="Name"
      :counter="10"
      :rules="roleRules"
      label="Name"
      required
    ></v-text-field>
    <v-text-field
      v-model="LevelInFamily"
      :counter="10"
      :rules="numberRules"
      label="LevelInFamily"
    ></v-text-field>
    <v-text-field
      v-model="Gender"
      :counter="10"
      :rules="roleRules"
      label="Gender"
    ></v-text-field>
    <v-text-field
      v-model="LevelInParentage"
      :counter="10"
      :rules="numberRules"
      label="LevelInParentage"
    ></v-text-field>
    <v-btn
      :disabled="!valid"
      color="success"
      class="mr-4"
      @click="update"
    >
      Update
    </v-btn>
    <v-btn
      :disabled="!valid"
      color="success"
      class="mr-4"
      @click="deletef"
    >
      Delete
    </v-btn>
  </v-form>
</v-container>
</template>
<script>
import api from '../../api';
import errorAlert from '../../components/ErrorAlert';
  export default {
    components:{
      errorAlert
    },
    data: () => ({
      valid: true,
      error:false,
      Name: '',
      Gender: '',
      LevelInParentage: 0,
      LevelInFamily: 0,
      numberRules:[
        v => v >= 0 || 'Must is a postive number'
      ],
      roleRules: [
        v => !!v || 'This is required',
        v => (v && v.length <= 100) || 'This field must be less than 100 characters',
      ],
    }),
    mounted() {
      this.getData();
    },
    methods: {
      getData(){
        api.getPersonById(this.$route.params.id).then(data=>{
          var p = data.data.data;
          this.Name = p.name;
          this.Gender = p.gender;
          this.LevelInParentage = p.levelInParentage;
          this.LevelInFamily = p.levelInFamily;
        }).catch(error => {
          console.log(error);
          this.error= true;
           if (error.status === 401 && error.headers.has('Token-Expired')) {
              this.$router.push("/signIn");
          }
        });
      },
      update(){
        api.updatePerson(this.$route.params.id,{
          "Id":this.$route.params.id,
          "Name" : this.Name,
          "Gender" : this.Gender,
          "LevelInParentage" : parseInt(this.LevelInParentage),
          "LevelInFamily" : parseInt(this.LevelInFamily)
        }).then(data => {
        console.log(data);
        this.error= false;
        this.$router.push("/management-person");
        }).catch(error => {
          console.log(error);
          this.error= true;
          if (error.status === 401 && error.headers.has('Token-Expired')) {
              this.$router.push("/signIn");
          }
        });
      },
      deletef(){
        api.deletePerson(this.$route.params.id)
        .then(data => {
        console.log(data);
        this.error= false;
        this.$router.push("/management-person");
        }).catch(response  => {
          console.log(response);
          this.error= true;
          if (response.status === 401 && response.headers.has('token-expired')) {
              this.$router.push("/signIn");
          }
        });
      }
    },
  }
</script>