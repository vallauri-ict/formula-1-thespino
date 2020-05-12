const ViewHome = {
  template: `
    <div>
    <el-row style="background:#F8F8F8;">
      <img src="/assets/img/f1-illustration.gif" style="display:block;width:100%;max-width:800px;margin:0 auto 40px auto;border-radius:3px">
    </el-row>

      <el-row>
        <h1 class="text-center">Welcome to FORMULA 1</h1>
      </el-row>

      <el-row class="text-center">
        <el-button v-for="(link) in links" type="primary" :to="link.route" @click="handleActionClick(link)">{{ link.title }}</el-button>
      </el-row>


      <el-row class="text-center" style="margin-top:120px;padding: 40px 0;border-top:1px solid #DDDDDD;">
        <div><b>SPINONI GIORGIO</b></div>
        <div>5B INF&nbsp;&nbsp;|&nbsp;&nbsp;S.Y. 2019/20</div>
        <div>IIS G. Vallauri - Fossano (CN)</div>
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
    handleActionClick: function (link) {
      console.log(link);
      router.push(link.route)
    }
  }
};