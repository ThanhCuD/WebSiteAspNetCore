<template>
  <div class="text-center">
    <v-dialog width="500" v-model="dialog">
      <template v-slot:activator="{ on }">
        <v-btn class="success" dark v-on="on">Edit Role</v-btn>
      </template>
      <v-card>
        <v-card-title class="headline grey lighten-2" primary-title>Edit Role</v-card-title>
        <v-card-text>
          <v-form ref="form" class="px-3">
            <v-text-field label="Name of Role" v-model="name" :rules = "inputRules" prepend-icon="persion"></v-text-field>
            <v-btn color="primary" @click="Submit" :loading="loading">Submit</v-btn>
          </v-form>
        </v-card-text>
      </v-card>
    </v-dialog>
  </div>
</template>
<script>
import api from '../api';
export default {
  props: ['idrole'],
  data(){
    return {
      id : '',
      name:'',
      inputRules: [
        v=>v.length>=3 || "Minimmum length = 3"
      ],
      dialog : false,
      loading: false
    }
  },
  methods: {
    async Submit(){
      if(this.$refs.form.validate()){
        this.loading = true;
        await api.updateRole({'id':this.idrole,'name':this.name}).then(()=>{
          this.$emit('handleIncrement')
        }).catch(error => {
          console.log(error);
        });
      }
      this.loading = false;
      this.dialog = false;
    }
  }
}
</script>