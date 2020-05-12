using System.Web.Http;

using FormulaOneDll.Database;
using FormulaOneDll.Database.Models;
using FormulaOneWebAPI.Resources;

namespace FormulaOneWebAPI.Controllers
{
    public class CountriesController : ApiController
    {
        private Tools DB = new Tools();

        // GET: api/Countries
        public ListResource<Country> Get(int page = 1, int limit = 10, string query = "")
        {
            return new ListResource<Country>(DB.API___Countries_List(page, limit, query), page);
        }

        // GET: api/Countries/AD
        public Country Get(string code)
        {
            return DB.API___Countries_Get(code);
        }
    }
}
