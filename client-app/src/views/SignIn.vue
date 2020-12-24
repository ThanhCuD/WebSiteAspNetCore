<template>
<v-container>
<div id="visa">
    <h1>Sign In</h1>
    <form>
      <label for="email">Email Address:</label>
      <v-text-field prepend-icon="person" name="Username"  v-model="email" label="Username"></v-text-field>
      <span v-if="msgemail">{{msgemail}}</span>
      <label for="password">Password:</label>
      <v-text-field prepend-icon="lock" name="Password" label="Password" v-model="password" type="password"></v-text-field>
      <span v-if="msgpassword">{{msgpassword}}</span><br>
      <v-btn @click = "fetchAPIData">
        Login
      </v-btn>
    </form>
</div>
</v-container>
</template>
<script>
export default {
  name: 'SignIn',
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
      let difference = 6 - value.length;
      if (value.length<6) {
        this.msgpassword = 'Must be 6 characters! '+ difference + ' characters left' ;
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

      postData("https://localhost:44365/User/Login", {
          "UserName" : this.email,
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