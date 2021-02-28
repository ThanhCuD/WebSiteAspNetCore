<template>
  <div class="text-center">
    <v-pagination
      v-model="page"
      :length="sumPage"
       @input="onPageChange"
    ></v-pagination>
  </div>
</template>
<script>
  export default {
    props : ['data','currentPage','totalPage'],
    data () {
      return {
        page: this.currentPage,
        sumPage : this.totalPage
      }
    },
    methods : {
      onPageChange (page){
        console.log(page)
      }
    }
  }
</script>