const App = {
  template: `
    <div>
      <el-menu mode="horizontal">
        <el-menu-item class="app-title" type="primary" @click="handleMenuItemClick({route: '/', title: 'Home'})"><b>Formula 1</b></el-menu-item>
        <el-menu-item v-for="(link) in links" type="primary" @click="handleMenuItemClick(link)">{{ link.title }}</el-menu-item>
      </el-menu>

      <router-view></router-view>
    </div>
  `,
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