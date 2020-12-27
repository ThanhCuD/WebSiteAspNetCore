import axios from "axios";

let baseurl =
  process.env.NODE_ENV == "development"
    ? "https://localhost:44365"
    : "https://localhost:44365";

const instance = axios.create();
const get = (params, url) => instance.get(`${baseurl}/${url}`, params);
const post = (params, url) => instance.post(`${baseurl}/${url}`, params);
const postWithoutToken = (params, url) =>
axios.post(`${baseurl}/${url}`, params);
export default {
  axiosInstance: instance,
  authenticate: (params) => postWithoutToken(params, "Users/authenticate"),
  createRole: (params) => post(params,"Administrative/CreateRole"),
  getRoles:()=>get({},"Administrative/GetRoles"),
  deleteRole:(id)=>post({'id':id},"Administrative/DeleteRole")
}