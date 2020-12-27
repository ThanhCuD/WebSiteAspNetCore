<template>
  <div>
    <v-alert
      v-model="value"
      dense
      outlined
      type="error"
    >
      I'm a dense alert with the <strong>outlined</strong> prop and a <strong>type</strong> of error
    </v-alert>
  </div>
</template>
<script>
  export default {
    props:{
      value : Boolean
    },
  }
</script>