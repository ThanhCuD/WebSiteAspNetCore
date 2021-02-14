import axios from "axios";

let baseurl =
  process.env.NODE_ENV == "development"
    ? "https://localhost:44366"
    : "https://localhost:44366";

const instance = axios.create();
const pageSize  = 5;
const apiVersion = 'v1';
const get = (params, url) => instance.get(`${baseurl}/${url}`, params);
const post = (params, url) => instance.post(`${baseurl}/${url}`, params);
const put =  (id, params, url) => instance.put(`${baseurl}/${url}/${id}`, params);
const deletef = (id,url) => instance.delete(`${baseurl}/${url}/${id}`);
const postWithoutToken = (params, url) =>
axios.post(`${baseurl}/${url}`, params);
export default {
  axiosInstance: instance,
  authenticate: (params) => postWithoutToken(params, "Users/authenticate"),
  createRole: (params) => post(params,"api/Roles/createRole"),
  getRoles:()=>get({},"api/Roles"),
  deleteRole:(id)=>post({'id':id},"api/Roles/deleteRole"),
  updateRole:(params)=>post(params,"api/Roles/updateRole"),
  getPersons:(pnumber)=>get({},"api/"+apiVersion+ "/Person" +"?PageNumber="+pnumber +"&PageSize=" +pageSize),
  createPerson:(params)=>post(params,"api/"+apiVersion+ "/Person"),
  getPersonById:(id)=>get({},"api/"+apiVersion+ "/Person" +"/"+id),
  updatePerson:(id,param) =>put(id,param,"api/"+apiVersion+ "/Person"),
  deletePerson:(id) =>deletef(id,"api/"+apiVersion+ "/Person"),
  searchPersons:(pnumber,searchValue)=>get({},
    "api/"+apiVersion+ "/Person" +"?PageNumber="+pnumber +"&PageSize=" +pageSize+
    (searchValue!=null?"&Name="+searchValue:"")),
}