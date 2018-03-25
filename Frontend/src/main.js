import Vue from "vue";
import Moment from "moment";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import "./registerServiceWorker";

Vue.config.productionTip = false;

Moment.locale("pl");

Vue.prototype.$bus = new Vue();
Vue.prototype.moment = Moment;

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
