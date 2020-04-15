using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using FormulaOneDll.Database;
using FormulaOneDll.Database.Models;

namespace FormulaOneWebAPI.Controllers
{
    public class TeamsController : ApiController
    {
        private Tools DB = new Tools();

        // GET: api/Teams
        public IEnumerable<Team> Get()
        {
            return DB.Teams__GetAll().Values.ToList();
        }

        // GET: api/Teams/5
        public Team Get(int id)
        {
            return DB.Teams__Get(id);
        }

        // POST: api/Teams
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Teams/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Teams/5
        public void Delete(int id)
        {
        }
    }
}
