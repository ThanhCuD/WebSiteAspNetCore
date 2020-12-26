import Vue from "vue";
import Vuex from "vuex";

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
      },
      logout(state) {
        state.auth = '';
        sessionStorage.setItem("auth", '');
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