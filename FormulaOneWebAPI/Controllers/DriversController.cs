using System.Web.Http;

using FormulaOneDll.Database;
using FormulaOneDll.Database.Models;
using FormulaOneWebAPI.Resources;

namespace FormulaOneWebAPI.Controllers
{
    public class DriversController : ApiController
    {
        private Tools DB = new Tools();

        // GET: api/Drivers
        public ListResource<Driver> Get(int page = 1, int limit = 10, string query = "")
        {
            return new ListResource<Driver>(DB.API___Drivers_List(page, limit, query), page);
        }

        // GET: api/Drivers/5
        public Driver Get(int id)
        {
            return DB.API___Drivers_Get(id);
        }
    }
}
