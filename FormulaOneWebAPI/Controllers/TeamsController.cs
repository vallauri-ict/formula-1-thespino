using System.Web.Http;

using FormulaOneDll.Database;
using FormulaOneDll.Database.Models;
using FormulaOneWebAPI.Resources;

namespace FormulaOneWebAPI.Controllers
{
    public class TeamsController : ApiController
    {
        private Tools DB = new Tools();

        // GET: api/Teams
        public ListResource<Team> Get(int page = 1, int limit = 10, string query = "")
        {
            return new ListResource<Team>(DB.API___Teams_List(page, limit, query), page);
        }

        // GET: api/Teams/5
        public Team Get(int id)
        {
            return DB.API___Teams_Get(id);
        }
    }
}
