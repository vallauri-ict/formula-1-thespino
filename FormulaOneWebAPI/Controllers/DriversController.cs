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
    public class DriversController : ApiController
    {
        private Tools DB = new Tools();

        // GET: api/Drivers
        public IEnumerable<Driver> Get()
        {
            return DB.Drivers__GetAll().Values.ToList();
        }

        // GET: api/Drivers/5
        public Driver Get(int id)
        {
            return DB.Drivers__Get(id);
        }

        // POST: api/Drivers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Drivers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Drivers/5
        public void Delete(int id)
        {
        }
    }
}
