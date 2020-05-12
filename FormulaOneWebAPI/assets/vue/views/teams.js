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

      <el-table
        :data="tableData"
        style="width: 100%">
        <el-table-column
          prop="Id"
          label="Id"
          sortable
          width="60">
        </el-table-column>
        <el-table-column
          prop="Name"
          label="Name"
          sortable>
        </el-table-column>
        <el-table-column
          prop="FullName"
          label="FullName"
          sortable>
        </el-table-column>
        <el-table-column
          prop="Country.Code"
          label="Country"
          sortable>
        </el-table-column>
        <el-table-column
          prop="PowerUnit"
          label="PowerUnit"
          sortable>
        </el-table-column>
        <el-table-column
          prop="TechnicalChief"
          label="TechnicalChief"
          sortable>
        </el-table-column>
        <el-table-column
          prop="Chassis"
          label="Chassis"
          sortable>
        </el-table-column>
        <el-table-column
          prop="Driver1.LastName"
          label="FirstDriver"
          sortable>
        </el-table-column>
        <el-table-column
          prop="Driver2.LastName"
          label="FirstDriver"
          sortable>
        </el-table-column>

        <el-table-column
          label="Actions"
          width="100">
          <span slot-scope="scope">
            <el-link :href="'https://www.formula1.com/en/teams/' + convertName(scope) + '.html'" target="_blank" :underline="false">
              <i class="el-icon-info" style="display:block;font-size:1.5em;padding:5px"></i>
            </el-link>
          </span>
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
      ResourceTeam.list(this.query).then((response) => {
        this.tableData = response.data.Data;
        this.total = response.data.Count;
        this.loading = false;
      });
    },

    convertName: function (scope) {
      return scope.row.Name.split(' ').join('-');
    },
  },
};