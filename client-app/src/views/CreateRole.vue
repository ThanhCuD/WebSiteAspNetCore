<template>
<v-container class="my-5">
<errorAlert :value="error"></errorAlert>
  <v-form
    ref="form"
    v-model="valid"
    lazy-validation
  >
    <v-text-field
      v-model="role"
      :counter="10"
      :rules="roleRules"
      label="Name"
      required
    ></v-text-field>
    <v-btn
      :disabled="!valid"
      color="success"
      class="mr-4"
      @click="validateAndSubmit"
    >
      Submit
    </v-btn>
  </v-form>
</v-container>
</template>
<script>
import api from '../api';
import errorAlert from '../components/ErrorAlert';
  export default {
    components:{
      errorAlert
    },
    data: () => ({
      valid: true,
      error:false,
      role: '',
      roleRules: [
        v => !!v || 'Role Name is required',
        v => (v && v.length <= 10) || 'Role Name must be less than 10 characters',
      ],
    }),
    methods: {
      validateAndSubmit () {
        var valid = this.$refs.form.validate();
        if(!valid){
           return;
        }
        api.createRole({
          "Name" : this.role,
        }).then(data => {
        console.log(data);
        this.error= false;
        this.$router.push("/");

        }).catch(error => {
          console.log(error);
          this.error= true;
        });
      }
    },
  }
</script>