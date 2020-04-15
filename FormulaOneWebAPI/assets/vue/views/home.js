const ViewHome = {
  template: `
    <div>
      <el-row>
        <h1 class="text-center">Here's what you can do</h1>
      </el-row>

      <el-row class="text-center">
        <el-button v-for="(link) in links" type="primary" :to="link.route" @click="handleActionClick(link)">{{ link.title }}</el-button>
      </el-row>
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
        }
      ],
    };
  },
  methods: {
    handleActionClick: function (link) {
      console.log(link);
      router.push(link.route)
    }
  }
};