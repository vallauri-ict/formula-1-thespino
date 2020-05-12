using System.Collections.Generic;
using System.Web.Http;

using FormulaOneDll.Database;
using FormulaOneDll.Database.Models;
using FormulaOneWebAPI.Resources;

namespace FormulaOneWebAPI.Controllers
{
    public class ResultsController : ApiController
    {
        private Tools DB = new Tools();

        // GET: api/Results
        public ListResource<Result> Get(int page = 1, int limit = 10, string query = "")
        {
            return new ListResource<Result>(DB.API___Results_List(page, limit, query), page);
        }

        // GET: api/Results/5
        public Result Get(int id)
        {
            return DB.API___Results_Get(id);
        }

        // GET: api/Results/of-race/5
        [AcceptVerbs("GET")]
        public IEnumerable<Result> OfRace(int id)
        {
            return DB.API___Results_OfRace(id);
        }
    }
}
