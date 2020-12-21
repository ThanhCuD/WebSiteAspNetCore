<template>
  <div id="visa">
    <h1>Create a New Account</h1>
    <form>
      <label for="full name">Full Name:</label>
      <input type="text" v-model="name" required>
      <br>
      <label for="email">Email Address:</label>
      <input type="text" v-model="email" required> <br>
      <span v-if="msg.email">{{msg.email}}</span>
      <label for="password">Password:</label>
      <input type="text" v-model="password" required><br>
      <span v-if="msg.password">{{msg.password}}</span>
      <button type = "button" id = "get-joke" @click = "fetchAPIData">Get a Joke!!</button>
    </form>
</div>
</template>
<script>
// import axios from 'axios';
export default {
  name: 'Registration',
  data(){
    return {
      name: '',
      password: '',
      email: '',
      msg: [],
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
        this.msg['email'] = '';
      } else{
        this.msg['email'] = 'Invalid Email Address';
      } 
    },
    validatePassword(value){
      let difference = 8 - value.length;
      if (value.length<8) {
        this.msg['password'] = 'Must be 8 characters! '+ difference + ' characters left' ;
      } else {
         this.msg['password'] = '';
      }
    },
    fetchAPIData(){
      //  axios
      // .get('https://api.coindesk.com/v1/bpi/currentprice.json')
      // .then(response => (console.log(response)))
      async function postData(url = '', data = {}) {
          // Default options are marked with *
        const response = await fetch(url, {
          method: 'POST', // *GET, POST, PUT, DELETE, etc.
          mode: 'cors', // no-cors, *cors, same-origin
          cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
          credentials: 'include', // include, *same-origin, omit
          headers: {
            'Content-Type': 'application/json'
            // 'Content-Type': 'application/x-www-form-urlencoded',
          },
          redirect: 'follow', // manual, *follow, error
          referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
          body: JSON.stringify(data) // body data type must match "Content-Type" header
        });
        return response.json(); // parses JSON response into native JavaScript objects
      }
      postData('https://localhost:44365/User/RegisterUser', { "Email" : "Thanh.duc@websparks.sg" })
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