using LabMvcWebApi.Models;
using LabMvcWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Data;

namespace LabMvcWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: api/Employee
        [ResponseType(typeof(IEnumerable<Employee>))]
        public IEnumerable<Employee> Get()
        {
            return GlobalAppRep.listEmployees;
        }

        // GET: api/Employee/5
        [ResponseType(typeof(Employee))]
        public Employee Get(int id)
        {
            return GlobalAppRep.listEmployees.Where(x => x.Empl_id.Equals(id)).SingleOrDefault();
        }

        // POST: api/Employee
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Employee/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Employee/5
        public void Delete(int id)
        {
            GlobalAppRep.listEmployees.Remove(GlobalAppRep.listEmployees.Where(x => x.Empl_id.Equals(id)).SingleOrDefault());
        }
    }
}
