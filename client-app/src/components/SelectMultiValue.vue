<template>
  <v-container fluid>
    <v-row>
      <v-col cols="12">
        <v-combobox
          v-model="select"
          :items="items"
          label="Parent Name"
          multiple
          outlined
          dense
        ></v-combobox>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
  export default {
    props: ['sourceNameParent'],
    data () {
      return {
        select: [],
        items: [
        ],
      }
    },
    mounted (){
       this.select = this.sourceNameParent;
       this.items = this.sourceNameParent;
    }
  }
</script>