import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    profile: {},
    publicBlogs: [],
    myBlogs: []
  },
  mutations: {
    setProfile(state, profile) {
      state.profile = profile;
    },
    setPublicBlogs(state, blogs) {
      state.publicBlogs = blogs;
    },
    setMyBlogs(state, data) {
      state.myBlogs = data;
    }
  },
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },

    async getBlogs({ commit, dispatch }) {
      let res = await api.get("blogs");
      commit("setPublicBlogs", res.data);
    },

    async getMyBlogs({ commit }) {
      let res = await api.get("blogs/myBlogs");
      commit("setMyBlogs", res.data);
    }
  }
});
