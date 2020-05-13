const App = {
  template: `
    <div :style="{paddingBottom: (device == 'mobile' ? '50px' : '')}">
      <el-menu v-if="device == 'desktop'" mode="horizontal">
        <el-menu-item class="app-title" type="primary" @click="handleMenuItemClick({route: '/', title: 'Home'})"><img src="/assets/img/f1_logo.svg" style="height:calc(100% - 40px);padding:20px 0;"></el-menu-item>
        <el-menu-item v-for="(link) in links" type="primary" @click="handleMenuItemClick(link)">{{ link.title }}</el-menu-item>
      </el-menu>

      <router-view></router-view>

      <CustomFooter></CustomFooter>

      <el-menu v-if="device == 'mobile'" mode="horizontal" class="bottom-navigation">
        <el-menu-item type="primary" @click="handleMenuItemClick({route: '/', title: 'Home', icon: 'el-icon-house'})"><i class="el-icon-house"></i><br><span>Home</span></el-menu-item>
        <el-menu-item v-for="(link) in links" type="primary" @click="handleMenuItemClick(link)"><i :class="link.icon"></i><br><span>{{ link.title }}</span></el-menu-item>
      </el-menu>
    </div>
  `,
  components: {
    CustomFooter,
  },
  data: function () {
    return {
      device: 'desktop',

      links: [
        {
          route: '/countries',
          title: 'Countries',
          icon: 'el-icon-discover'
        },
        {
          route: '/drivers',
          title: 'Drivers',
          icon: 'el-icon-user'
        },
        {
          route: '/teams',
          title: 'Teams',
          icon: 'el-icon-collection'
        },
        {
          route: '/circuits',
          title: 'Circuits',
          icon: 'el-icon-office-building'
        },
        {
          route: '/races',
          title: 'Races',
          icon: 'el-icon-stopwatch'
        }
      ],
    };
  },
  created: function () {
    this.handleWindowResize();
    window.addEventListener('resize', this.handleWindowResize);
  },
  methods: {
    handleMenuItemClick: function (link) {
      router.push(link.route);
    },

    handleWindowResize: function () {
      const width = (window.innerWidth > 0) ? window.innerWidth : screen.width;
      console.log(this);
      this.device = width <= 900 ? 'mobile' : 'desktop';
    }
  }
};