import axios from "axios";

let baseurl =
  process.env.NODE_ENV == "development"
    ? "https://localhost:44365"
    : "https://localhost:44365";

const instance = axios.create();
// const get = (params, url) => instance.get(`${baseurl}/${url}`, params);
const post = (params, url) => instance.post(`${baseurl}/${url}`, params);
const postWithoutToken = (params, url) =>
  axios.post(`${baseurl}/${url}`, params);
// const getWithDelay = (params, url) =>
//   new Promise((resolve) => {
//     setTimeout(
//       () => resolve(get(params, url)),
//       500 + Math.floor(Math.random() * 1000)
//     );
//   });
//   const postFile = (data, url) => instance.post(`${baseurl}/${url}`, data);
  export default {
    axiosInstance: instance,
    authenticate: (params) => postWithoutToken(params, "Users/authenticate"),
    createRole: (params) => post(params,"Administrative/CreateRole")
  }