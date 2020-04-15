const ViewDrivers = {
  template: `
    <div>
      <el-form label-width="120px" style="padding:10px 20px;margin:0">
        <el-form-item label="Look for ID">
          <el-input v-model="searchId" @input="handleIdInputChange"></el-input>
        </el-form-item>
      </el-form>
      <el-table
        :data="tableData"
        style="width: 100%">
        <el-table-column
          prop="Id"
          label="Id"
          sortable
          width="180">
        </el-table-column>
        <el-table-column
          prop="Firstname"
          label="FirstName"
          sortable>
        </el-table-column>
        <el-table-column
          prop="Lastname"
          label="LastName"
          sortable>
        </el-table-column>
        <el-table-column
          prop="Dob"
          label="Dob"
          sortable>
        </el-table-column>
        <el-table-column
          prop="PlaceOfBirth"
          label="PlaceOfBirth"
          sortable>
        </el-table-column>
        <el-table-column
          prop="Country.Code"
          label="Country"
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
      ResourceDriver.list().then((response) => {
        this.tableData = response.data;
      });
    },
    getGet: function () {
      ResourceDriver.get(this.searchId).then((response) => {
        this.tableData = [response.data];
      });
    },
    handleIdInputChange: function () {
      if (this.searchId ==='') this.getList();
      else this.getGet();
    },
  },
};