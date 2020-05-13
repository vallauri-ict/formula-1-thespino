const ViewTeams = {
  template: `
    <div v-loading="loading">
      <el-input
        v-model="query.query"
        placeholder="Search and press enter"
        prefix-icon="el-icon-search"
        size="mini"
        style="margin:10px 20px;width:200px;"
        @change="getList"
      ></el-input>


      <div v-if="tableData.length == 0" class="text-center" style="opacity:0.7">
        <p>No data</p>
      </div>

      <el-row style="padding:15px">
        <el-col v-for="team of tableData" :sm="24" :md="12" class="standard-card">
          <el-card shadow="hover" @click.native="handleCardClick(team)">
            <div class="div-info">
              <span class="standard-card-small">{{ team.PowerUnit }}</span>
              <br>
              <span class="standard-card-big">{{ team.Name }}</span>
            </div>
            <img :src="team.ImageUrl" class="center">
          </el-card>
        </el-col>
      </el-row>

      <el-dialog v-if="selected != null" title="Team details" :visible.sync="dialogVisible">
        <el-row>
          <el-col :sm="24" :md="14" style="line-height:2em">
            <table style="width:100%;margin:30px 0">
              <tbody>
                <tr>
                  <td>Full name</td>
                  <td><b>{{ selected.FullName }}<b></td>
                </tr>
                <tr>
                  <td>Short name</td>
                  <td><b>{{ selected.Name }}<b></td>
                </tr>
                <tr>
                  <td>Power unit</td>
                  <td><b>{{ selected.PowerUnit }}<b></td>
                </tr>
                <tr>
                  <td>Technical Chief</td>
                  <td><b>{{ selected.TechnicalChief }}<b></td>
                </tr>
                <tr>
                  <td>Chassis</td>
                  <td><b>{{ selected.Chassis }}<b></td>
                </tr>
                <tr>
                  <td>Country</td>
                  <td><b>{{ selected.Country.Name }}<b></td>
                </tr>
                <tr>
                  <td>First driver</td>
                  <td><b>{{ selected.Driver1.LastName }} {{ selected.Driver1.FirstName }}<b></td>
                </tr>
                <tr>
                  <td>Second driver</td>
                  <td><b>{{ selected.Driver2.LastName }} {{ selected.Driver2.FirstName }}<b></td>
                </tr>
              </tbody>
            </table>
          </el-col>

          <el-col :sm="24" :md="10">
            <img :src="selected.ImageUrl" style="width:100%">
          </el-col>
        </el-row>

        <div slot="footer" class="dialog-footer">
          <el-button @click="dialogVisible=false">Close</el-button>
          <el-button type="primary" icon="el-icon-info" @click="handleMoreInfoClick(selected)">More info</el-button>
        </div>
      </el-dialog>

      <el-pagination
        @size-change="getList"
        @current-change="getList"
        :page-sizes="[10, 50, 100, 200, 300]"
        :page-size.sync="query.limit"
        :current-page.sync="query.page"
        :page-size="query.limit"
        :total="total"
        layout="total, sizes, prev, pager, next, jumper"
        background>
      </el-pagination>
    </div>
  `,
  data: function () {
    return {
      query: {
        page: 1,
        limit: 10,
        query: '',
      },
      total: 1,
      tableData: [],
      dialogVisible: false,
      selected: null,
      loading: true,
    };
  },
  created: function () {
    this.getList();
  },
  methods: {
    getList: function () {
      this.loading = true;
      ResourceTeam.list(this.query).then((response) => {
        this.tableData = response.data.Data;
        this.total = response.data.Count;
        this.loading = false;
      });
    },

    convertName: function (team) {
      return team.Name.split(' ').join('-');
    },

    handleMoreInfoClick(team) {
      window.open('https://www.formula1.com/en/teams/' + this.convertName(team) + '.html', '_blank');
    },

    handleCardClick(team) {
      this.selected = team;
      this.$nextTick(() => {
        this.dialogVisible = true;
      });
    }
  },
};