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
    public class CountriesController : ApiController
    {
        private Tools DB = new Tools();

        // GET: api/Countries
        public IEnumerable<Country> Get()
        {
            return DB.Countries__GetAll().Values.ToList();
        }

        // GET: api/Countries/AD
        public Country Get(string code)
        {
            return DB.Countries__Get(code);
        }

        // POST: api/Countries
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Countries/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Countries/5
        public void Delete(int id)
        {
        }
    }
}
