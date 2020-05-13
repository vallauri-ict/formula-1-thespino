const App = {
  template: `
    <div>
      <el-menu mode="horizontal">
        <el-menu-item class="app-title" type="primary" @click="handleMenuItemClick({route: '/', title: 'Home'})"><img src="/assets/img/f1_logo.svg" style="height:calc(100% - 40px);padding:20px 0;"></el-menu-item>
        <el-menu-item v-for="(link) in links" type="primary" @click="handleMenuItemClick(link)">{{ link.title }}</el-menu-item>
      </el-menu>

      <router-view></router-view>

      <CustomFooter></CustomFooter>
    </div>
  `,
  components: {
    CustomFooter,
  },
  data: function () {
    return {
      links: [
        {
          route: '/countries',
          title: 'Countries'
        },
        {
          route: '/drivers',
          title: 'Drivers'
        },
        {
          route: '/teams',
          title: 'Teams'
        },
        {
          route: '/circuits',
          title: 'Circuits'
        },
        {
          route: '/races',
          title: 'Races'
        }
      ],
    };
  },
  methods: {
    handleMenuItemClick: function (link) {
      router.push(link.route);
    }
  }
};