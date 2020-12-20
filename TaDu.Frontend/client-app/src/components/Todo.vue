<template>
  <div class="main">
    <input v-model='newTodo'>
    <br/>
    <button @click="Add">Add</button>
    <ul>
      <Item v-for="(todo,i) in toDoList" :key="i" :item="todo" @Remove="Remove"></Item>
    </ul>
  </div>
</template>

<script>
import Item from './TodoItem.vue'
export default {
  name: 'Todo',
  components: {
    Item
  },
  data () {
    return{
     newTodo : '',
     toDoList : [ 
       {
         id:0,
         text : "Quet nha"
       },
       {
         id:1,
         text : "Rua chen"
       }
     ]
    }
  },
  methods:{
     Add(){
      this.toDoList.push({id : new Date().valueOf(),text: this.newTodo});
      this.newTodo = '';
    },
    Remove(i){
      this.toDoList = this.toDoList.filter(todo  => todo.id  != i);
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
