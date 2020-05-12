const ViewDrivers = {
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
        <el-col v-for="driver of tableData" :xs="24" :sm="12" :md="6" class="standard-card">
          <el-card shadow="hover" @click.native="handleCardClick(driver)">
            <div class="div-info">
              <span class="standard-card-small">{{ driver.FirstName }}</span>
              <br>
              <span class="standard-card-big">{{ driver.LastName }}</span>
            </div>
            <img :src="driver.ImageUrl" class="bottom">
          </el-card>
        </el-col>
      </el-row>

      <el-dialog v-if="selected != null" title="Driver details" :visible.sync="dialogVisible">
        <el-row>
          <el-col :sm="24" :md="14" style="line-height:2em">
            <table style="width:100%;margin-top:30px">
              <tbody>
                <tr>
                  <td>First name</td>
                  <td><b>{{ selected.FirstName }}<b></td>
                </tr>
                <tr>
                  <td>Last name</td>
                  <td><b>{{ selected.LastName }}<b></td>
                </tr>
                <tr>
                  <td>DOB</td>
                  <td><b>{{ new Date(selected.Dob).toLocaleDateString() }}<b></td>
                </tr>
                <tr>
                  <td>POB</td>
                  <td><b>{{ selected.Pob }}<b></td>
                </tr>
                <tr>
                  <td>Country</td>
                  <td><b>{{ selected.Country.Name }}<b></td>
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
          <el-button type="primary" @click="handleMoreInfoClick(selected)">More info</el-button>
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
      ResourceDriver.list(this.query).then((response) => {
        this.tableData = response.data.Data;
        this.total = response.data.Count;
        this.loading = false;
      });
    },

    convertName: function (driver) {
      return `${driver.FirstName.toLowerCase()}-${driver.LastName.toLowerCase()}`;
    },

    handleMoreInfoClick(driver) {
      window.open('https://www.formula1.com/en/drivers/' + this.convertName(driver) + '.html', '_blank');
    },

    handleCardClick(driver) {
      this.selected = driver;
      this.$nextTick(() => {
        this.dialogVisible = true;
      });
    }
  },
};