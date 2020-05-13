const ViewRaces = {
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
        <el-col v-for="race of tableData" :sm="24" :md="12" class="standard-card">
          <el-card shadow="hover" @click.native="handleCardClick(race)">
            <div class="div-info">
              <span class="standard-card-small">{{ race.Date == '0001-01-01T00:00:00' ? 'No date' : new Date(selected.Date).toLocaleDateString() }}</span>
              <br>
              <span class="standard-card-big">{{ race.Name }}</span>
            </div>
            <img :src="race.Circuit.ImageUrl" class="center" style="max-width:130px">
          </el-card>
        </el-col>
      </el-row>

      <el-dialog v-if="selected != null" title="Race details" :visible.sync="dialogVisible">
        <el-row>
          <el-col :sm="24" :md="14" style="line-height:2em">
            <table style="width:100%;margin:30px 0">
              <tbody>
                <tr>
                  <td>Name</td>
                  <td><b>{{ selected.Name }}<b></td>
                </tr>
                <tr>
                  <td>Circuit</td>
                  <td><b>{{ selected.Circuit.Name }}<b></td>
                </tr>
                <tr>
                  <td>Laps</td>
                  <td><b>{{ selected.Laps }}<b></td>
                </tr>
                <tr>
                  <td>Date</td>
                  <td><b>{{ selected.Date == '0001-01-01T00:00:00' ? 'Not defined yet' : new Date(selected.Date).toLocaleDateString() }}<b></td>
                </tr>
              </tbody>
            </table>
          </el-col>

          <el-col :sm="24" :md="10">
            <img :src="selected.Circuit.ImageUrl" style="width:100%">
          </el-col>
        </el-row>

        <el-row v-if="selectedResults != null">
          <el-table
            :data="selectedResults"
            style="width: 100%">
            <el-table-column
              prop="Driver.LastName"
              label="Driver"
              sortable>
            </el-table-column>
            <el-table-column
              prop="Score"
              label="Score"
              sortable
              width="100">
            </el-table-column>
            <el-table-column
              prop="Position"
              label="Position"
              sortable
              width="100">
            </el-table-column>
            <el-table-column
              prop="FastestLap"
              label="FastestLap"
              sortable
              width="130">
            </el-table-column>
          </el-table>
        </el-row>

        <div slot="footer" class="dialog-footer">
          <el-button @click="dialogVisible=false">Close</el-button>
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
      selectedResults: null,
      loading: true,
    };
  },
  created: function () {
    this.getList();
  },
  methods: {
    getList: function () {
      this.loading = true;
      ResourceRace.list(this.query).then((response) => {
        this.tableData = response.data.Data;
        this.total = response.data.Count;
        this.loading = false;
      });
    },

    getSelectedResults: function () {
      ResourceResult.ofRace(this.selected.Id).then((response) => {
        this.selectedResults = response.data;
      });
    },

    handleCardClick(race) {
      this.selected = race;
      this.getSelectedResults();

      this.$nextTick(() => {
        this.dialogVisible = true;
      });
    }
  },
};