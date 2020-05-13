const ViewCircuits = {
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
        <el-col v-for="circuit of tableData" :sm="24" :md="12" class="standard-card">
          <el-card shadow="hover" @click.native="handleCardClick(circuit)">
            <div class="div-info">
              <span class="standard-card-small">{{ circuit.Length }}</span>
              <br>
              <span class="standard-card-big">{{ circuit.Name }}</span>
            </div>
            <img :src="circuit.ImageUrl" class="center" style="max-width:130px">
          </el-card>
        </el-col>
      </el-row>

      <el-dialog v-if="selected != null" title="Circuit details" :visible.sync="dialogVisible">
        <el-row>
          <el-col :sm="24" :md="14" style="line-height:2em">
            <table style="width:100%;margin:30px 0">
              <tbody>
                <tr>
                  <td>Name</td>
                  <td><b>{{ selected.Name }}<b></td>
                </tr>
                <tr>
                  <td>Length</td>
                  <td><b>{{ selected.Length }}<b></td>
                </tr>
                <tr>
                  <td>Record Lap</td>
                  <td><b>{{ selected.RecordLap }}<b></td>
                </tr>
                <tr>
                  <td>Location</td>
                  <td><b>{{ selected.Location }}<b></td>
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
      ResourceCircuit.list(this.query).then((response) => {
        this.tableData = response.data.Data;
        this.total = response.data.Count;
        this.loading = false;
      });
    },

    handleCardClick(circuit) {
      this.selected = circuit;
      this.$nextTick(() => {
        this.dialogVisible = true;
      });
    }
  },
};