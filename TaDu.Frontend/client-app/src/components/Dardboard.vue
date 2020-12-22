<template>
  <div id="visa">
    <h1>Create a New Account</h1>
    <form>
      <label for="email">Email Address:</label>
      <input type="text" v-model="email" required> <br>
      <span v-if="msgemail">{{msgemail}}</span>
      <label for="password">Password:</label>
      <input type="text" v-model="password" required><br>
      <span v-if="msgpassword">{{msgpassword}}</span><br><br>
      <input type="button" id = "get-joke" @click = "fetchAPIData" value="Register">
    </form>
</div>
</template>
<script>
// import axios from 'axios';
export default {
  name: 'Dardboard',
  data(){
    return {
    }
  }
}
</script>
<style scoped>
#visa {
  margin: 20px auto;
  max-width: 700px;
  margin-bottom: 28px;
}
label{
  display: block;
  margin: 20px 0 10px;
}
span {
  padding-top: 0px;
  margin-top: 0px;
  font-size: 12px; color:red;
}
input {
  font-size: 30px;
  border: 1px double rgb(102, 97, 96) ;
  border-radius: 4px;
}
</style>