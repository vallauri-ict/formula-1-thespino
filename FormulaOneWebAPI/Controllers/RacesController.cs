using System.Web.Http;

using FormulaOneDll.Database;
using FormulaOneDll.Database.Models;
using FormulaOneWebAPI.Resources;

namespace FormulaOneWebAPI.Controllers
{
    public class RacesController : ApiController
    {
        private Tools DB = new Tools();

        // GET: api/Races
        public ListResource<Race> Get(int page = 1, int limit = 10, string query = "")
        {
            return new ListResource<Race>(DB.API___Races_List(page, limit, query), page);
        }

        // GET: api/Races/5
        public Race Get(int id)
        {
            return DB.API___Races_Get(id);
        }
    }
}
