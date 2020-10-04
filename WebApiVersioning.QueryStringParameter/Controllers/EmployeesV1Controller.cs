using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiVersioning.uQueryStringParameter.Models;

namespace WebApiVersioning.uQueryStringParameter.Controllers
{
    public class EmployeesV1Controller : ApiController
    {
        private List<EmployeeV1Model> employees = new List<EmployeeV1Model>()
        {
            new EmployeeV1Model() { EmployeeID = 101, EmployeeName = "Anurag"},
            new EmployeeV1Model() { EmployeeID = 102, EmployeeName = "Priyanka"},
            new EmployeeV1Model() { EmployeeID = 103, EmployeeName = "Sambit"},
            new EmployeeV1Model() { EmployeeID = 104, EmployeeName = "Preety"},
        };
        //Not use [Route] attribute 
        //[Route("api/v1/employees")]
        [HttpPost]
        public IEnumerable<EmployeeV1Model> Get()
        {
            return employees;
        }
        //[Route("api/v1/employees/{id}")]
        public EmployeeV1Model Get(int id)
        {
            return employees.FirstOrDefault(s => s.EmployeeID == id);
        }
    }
}