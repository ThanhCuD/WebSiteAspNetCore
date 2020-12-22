<template>
  <div id="visa">
    <h1>Create a New Account</h1>
    <form>
      <label for="email">Email Address:</label>
      <input type="text" v-model="email" required> <br>
      <span v-if="msgemail">{{msgemail}}</span>
      <label for="password">Password:</label>
      <input type="text" v-model="password" required><br>
      <span v-if="msgpassword">{{msgpassword}}</span>
      <input type="button" id = "get-joke" @click = "fetchAPIData" value="Register">
    </form>
</div>
</template>
<script>
// import axios from 'axios';
export default {
  name: 'Registration',
  data(){
    return {
      password: '',
      email: '',
      msgemail: '',
      msgpassword: ''
    }
  },
  watch: {
    email(value){
      // binding this to the data value in the email input
      this.email = value;
      this.validateEmail(value);
    },
    password(value){
      this.password = value;
      this.validatePassword(value);
    }
  },
  methods:{
    validateEmail(value){
      //eslint-disable-next-line
      if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(value))
      {
        this.msgemail = '';
      } else{
        this.msgemail = 'Invalid Email Address';
      } 
    },
    validatePassword(value){
      let difference = 8 - value.length;
      if (value.length<8) {
        this.msgpassword = 'Must be 8 characters! '+ difference + ' characters left' ;
      } else {
         this.msgpassword = '';
      }
    },
    fetchAPIData(){
      this.validateEmail(this.email);
      this.validatePassword(this.password);
      if(this.msgemail!=='' || this.msgpassword!==''){
        return;
      }
      async function postData(url = '',data) {
        const response = await fetch(url, {
          method: 'POST',
          headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(data)
        });
        return response.json(); // parses JSON response into native JavaScript objects
      }

      postData("https://localhost:44365/User/RegisterUser", {
          "Email" : this.email,
          "Password" : this.password
      })
      .then(data => {
        console.log(data); // JSON data parsed by `data.json()` call
      });
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