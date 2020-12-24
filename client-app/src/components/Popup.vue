<template>
  <div class="text-center">
    <v-dialog width="500" v-model="dialog">
      <template v-slot:activator="{ on }">
        <v-btn class="success" dark v-on="on">Add New Project</v-btn>
      </template>
      <v-card>
        <v-card-title class="headline grey lighten-2" primary-title>Add a New Project</v-card-title>
        <v-card-text>
          <v-form ref="form" class="px-3">
            <v-text-field label="Title" v-model="title" :rules = "inputRules" prepend-icon="folder"></v-text-field>
            <v-textarea label="Info" v-model="info" :rules = "inputRules" prepend-icon="edit"></v-textarea>

            <v-menu offset-y>
                    <template v-slot:activator="{ on, attrs }">
                       <v-col
                          cols="12"
                          sm="6"
                          md="6"
                          lg="6"
                        >
                      <v-text-field flat :rules = "inputRules"
                       prepend-icon="mdi-calendar-range"
                       label="Due Date" 
                       v-bind="attrs" v-on="on" elevation="0" :value="formatDat"></v-text-field>
                       </v-col>
                    </template>
                    <v-date-picker v-model="due"></v-date-picker>
                    </v-menu>

            <v-btn color="primary" @click="Submit" :loading="loading">Submit</v-btn>
          </v-form>
        </v-card-text>
      </v-card>
    </v-dialog>
  </div>
</template>
<script>
import format from 'date-fns/format';
import parseISO from 'date-fns/parseISO'
export default {
  data(){
    return {
      title:'',
      info:'',
      due: '',
      inputRules: [
        v=>v.length>=3 || "Minimmum length = 3"
      ],
      dialog : false,
      loading: false
    }
  },
  methods: {
    Submit(){
      if(this.$refs.form.validate()){
        console.log(this.title + " "+ this.info);
        this.loading = true;
        this.dialog = false;
      }
       this.loading = false;
    }
  },
  computed: {
    formatDat(){
      return this.due? format(parseISO(this.due), 'do MMM yyyy') : '';
    }
  }
}
</script>