// ROUTER

const routes = [
  { path: '/', component: ViewHome },
  { path: '/home', component: ViewHome },
  { path: '/countries', component: ViewCountries },
  { path: '/drivers', component: ViewDrivers },
  { path: '/teams', component: ViewTeams },
];

const router = new VueRouter({
  routes
});


// VUE

const vueinstance = new Vue({
  el: "#app",
  components: {
    'app': App
  },
  data: {
    ciao: 'sas',
  },
  methods: {
    request: function (uri) {
    }
  },
  router
});
