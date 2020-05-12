using System.Web.Http;

using FormulaOneDll.Database;
using FormulaOneDll.Database.Models;
using FormulaOneWebAPI.Resources;

namespace FormulaOneWebAPI.Controllers
{
    public class CircuitsController : ApiController
    {
        private Tools DB = new Tools();

        // GET: api/Circuits
        public ListResource<Circuit> Get(int page = 1, int limit = 10, string query = "")
        {
            return new ListResource<Circuit>(DB.API___Circuits_List(page, limit, query), page);
        }

        // GET: api/Circuits/5
        public Circuit Get(int id)
        {
            return DB.API___Circuits_Get(id);
        }
    }
}
