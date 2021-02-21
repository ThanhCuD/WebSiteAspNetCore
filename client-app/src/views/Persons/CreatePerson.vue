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
    <PopupSelectCard @selected="Selected"/>
    <SelectMultiValue v-bind:sourceNameParent="parentNameArr"/>
    <v-btn
      :disabled="!valid"
      color="success"
      class="mr-4"
      @click="validateAndSubmit"
    >
      Create
    </v-btn>
  </v-form>
  
  
</v-container>
</template>
<script>
import api from '../../api';
import errorAlert from '../../components/ErrorAlert';
import PopupSelectCard from '../../components/PopupSelectCard';
import SelectMultiValue from '../../components/SelectMultiValue';
  export default {
    components:{
      errorAlert,
      PopupSelectCard,
      SelectMultiValue
    },
    data: () => ({
      valid: true,
      error:false,
      Name: '',
      Gender: '',
      LevelInParentage: 0,
      LevelInFamily: 0,
      parentNameArr:[],
      parentId : 0,
      numberRules:[
        v => v >= 0 || 'Must is a postive number'
      ],
      roleRules: [
        v => !!v || 'This is required',
        v => (v && v.length <= 100) || 'This field must be less than 100 characters',
      ],
    }),
    methods: {
      validateAndSubmit () {
        var valid = this.$refs.form.validate();
        if(!valid){
           return;
        }
        api.createPerson({
          "Name" : this.Name,
          "Gender" : this.Gender,
          "LevelInParentage" : parseInt(this.LevelInParentage),
          "LevelInFamily" : parseInt(this.LevelInFamily),
          "IdParent" : this.parentId
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
      Selected:  function(id){
        console.log(id);
         api.getPersonById(id).then(data=>{
          var p = data.data.data;
          this.parentId  = p.id;
          if(!this.parentNameArr.includes(p.name)){
            this.parentNameArr.push(p.name);
          }
          console.log(this.parentNameArr);
        }).catch(error => {
          console.log(error);
          this.error= true;
           if (error.status === 401 && error.headers.has('Token-Expired')) {
              this.$router.push("/signIn");
          }
        });
      }
    },
  }
</script>