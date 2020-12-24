import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);
export default new Vuex.Store({
    state: {
      notification: false,
      auth: JSON.parse(sessionStorage.getItem("auth")),
      lookup: {}
    }

});