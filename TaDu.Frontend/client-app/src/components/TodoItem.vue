<template>
  <div>
    <li>
        <span>
            {{item.text}} 
        </span>
        <button @click="$emit('Remove',Number(item.id))">X</button>
      </li>
  </div>
</template>

<script>
export default {
  name: 'TodoItem',
  props: {
    item : Object
  },
  data () {
    return{
      data :"item"
    }
  }
}
</script>
<style scoped>
</style>
