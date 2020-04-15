const ViewCountries = {
  template: `
    <div>
      <el-form label-width="120px" style="padding:10px 20px;margin:0">
        <el-form-item label="Look for CODE">
          <el-input v-model="searchId" @input="handleIdInputChange"></el-input>
        </el-form-item>
      </el-form>
      <el-table
        :data="tableData"
        style="width: 100%">
        <el-table-column
          prop="Code"
          label="Code"
          sortable
          width="180">
        </el-table-column>
        <el-table-column
          prop="Name"
          label="Name"
          sortable>
        </el-table-column>
      </el-table>
    </div>
  `,
  data: function () {
    return {
      tableData: [],
      searchId: '',
    };
  },
  created: function () {
    this.getList();
  },
  methods: {
    getList: function () {
      ResourceCountry.list().then((response) => {
        this.tableData = response.data;
      });
    },
    getGet: function () {
      ResourceCountry.get(this.searchId).then((response) => {
        this.tableData = [response.data];
      });
    },
    handleIdInputChange: function () {
      if (this.searchId ==='') this.getList();
      else this.getGet();
    },
  }
};