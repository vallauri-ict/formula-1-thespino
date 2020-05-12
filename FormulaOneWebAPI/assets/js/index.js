// ROUTER

const routes = [
  { path: '/', component: ViewHome },
  { path: '/home', component: ViewHome },
  { path: '/countries', component: ViewCountries },
  { path: '/drivers', component: ViewDrivers },
  { path: '/teams', component: ViewTeams },
  { path: '/circuits', component: ViewCircuits },
  { path: '/races', component: ViewRaces },
];

const router = new VueRouter({
  routes
});

ELEMENT.locale(ELEMENT.lang.en);

// VUE

const vueinstance = new Vue({
  el: "#app",
  components: {
    'app': App
  },
  methods: {
    request: function (uri) {
    }
  },
  router
});
