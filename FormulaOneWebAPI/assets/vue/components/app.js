const App = {
  template: `
    <div>
      <el-menu mode="horizontal">
        <el-menu-item disabled class="app-title"><b>Formula 1</b></el-menu-item>
        <el-menu-item v-for="(link) in links" type="primary" @click="handleMenuItemClick(link)">{{ link.title }}</el-menu-item>
      </el-menu>
      <router-view></router-view>
    </div>
  `,
  data: function () {
    return {
      links: [
        {
          route: '/',
          title: 'Home'
        },
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