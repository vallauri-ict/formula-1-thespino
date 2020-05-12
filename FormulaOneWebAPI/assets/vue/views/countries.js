const ViewCountries = {
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
      <el-table
        :data="tableData"
        style="width: 100%">
        <el-table-column
          label="Flag"
          width="100">
          <span slot-scope="scope">
            <img :src="'/assets/img/flags/' + scope.row.Code.toLowerCase() + '.png'" style="height:25px">
          </span>
        </el-table-column>
        <el-table-column
          prop="Code"
          label="Code"
          sortable
          width="100">
        </el-table-column>
        <el-table-column
          prop="Name"
          label="Name"
          sortable>
        </el-table-column>
      </el-table>

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
      searchId: '',
      loading: true,
    };
  },
  created: function () {
    this.getList();
  },
  methods: {
    getList: function () {
      this.loading = true;
      ResourceCountry.list(this.query).then((response) => {
        this.tableData = response.data.Data;
        this.total = response.data.Count;
        this.loading = false;
      });
    },
  },
};