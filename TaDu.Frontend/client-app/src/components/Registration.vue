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
      <button type = "button" id = "get-joke" @click = "fetchAPIData">Register</button>
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

      //
// fetch("http://localhost:3001/SupportingDocuments/Save", {
//   "headers": {
//     "accept": "application/json, text/plain, */*",
//     "accept-language": "en-GB,en-US;q=0.9,en;q=0.8",
//     "authorization": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zaWQiOiI4N2VkZTc2Ni0xYTBhLTRjMjEtYmFjZS1jNGYwNTVjMTUyODQiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IlNETyIsIm5iZiI6MTYwODI4NzU4OSwiZXhwIjoxNjA4MzczOTg5LCJpYXQiOjE2MDgyODc1ODl9.5o8dgGYBqecJ6PhHvt2-MmY2OD_79hkVEXZ0iVGtBLQ",
//     "cache-control": "no-cache",
//     "content-type": "application/json;charset=UTF-8",
//     "pragma": "no-cache",
//     "sec-ch-ua": "\"Google Chrome\";v=\"87\", \" Not;A Brand\";v=\"99\", \"Chromium\";v=\"87\"",
//     "sec-ch-ua-mobile": "?0",
//     "sec-fetch-dest": "empty",
//     "sec-fetch-mode": "cors",
//     "sec-fetch-site": "same-origin"
//   },
//   "referrer": "http://localhost:3001/search-case/edit-case/step/6",
//   "referrerPolicy": "strict-origin-when-cross-origin",
//   "body": "{\"caseId\":59,\"personalDocs\":[{\"householdMemberId\":46,\"uploadedFiles\":[{\"selectedDocumentTypeId\":353,\"uploadedFileId\":465}]}],\"loggedUserId\":1}",
//   "method": "POST",
//   "mode": "cors",
//   "credentials": "include"
// });
      //
      async function postData(url = '',data) {
        // Default options are marked with *
        // const response = await fetch(url, {
        //   method: 'POST',
        //   headers: {
        //     'Accept': 'application/json',
        //     'Content-Type': 'application/json'
        //   }
        // });
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
    "Email" : "Thanh.duc@websparks.sg",
    "OTP" : "123"
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