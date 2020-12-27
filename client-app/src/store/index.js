import Vue from "vue";
import Vuex from "vuex";
import api from "../api";

Vue.use(Vuex);
export default new Vuex.Store({
    state: {
      notification: false,
      auth: JSON.parse(sessionStorage.getItem("auth")),
      lookup: {}
    },
    mutations: {
      login(state, payload) {
        state.auth = payload;
        sessionStorage.setItem("auth", JSON.stringify(payload));
        // api.axiosInstance.defaults.headers.common[
        //   "Authorization"
        // ] = `Bearer ${state.auth}`;
        console.log(api.axiosInstance.defaults.headers.common[
          "Authorization"
        ]);
      },
      logout(state) {
        state.auth = null;
        api.axiosInstance.defaults.headers.common["Authorization"] = "";
        sessionStorage.removeItem("auth");
      }
    },
    actions: {
      login({ commit }, payload) {
        commit("login", payload);
      },
      logout({ commit }) {
        commit("logout");
      }
    }
    
});