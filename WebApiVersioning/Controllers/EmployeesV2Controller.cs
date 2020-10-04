using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiVersioning.uUri.Models;

namespace WebApiVersioning.uUri.Controllers
{
    public class EmployeesV2Controller : ApiController
    {
        private List<EmployeeV2Model> employees = new List<EmployeeV2Model>()
        {
            new EmployeeV2Model() { EmployeeID = 101, FirstName = "Anurag", LastName = "Mohanty"},
            new EmployeeV2Model() { EmployeeID = 102, FirstName = "Priyanka", LastName = "Dewangan"},
            new EmployeeV2Model() { EmployeeID = 103, FirstName = "Sambit", LastName = "Satapathy"},
            new EmployeeV2Model() { EmployeeID = 104, FirstName = "Preety", LastName = "Tiwary"},
        };
        [Route("api/v2/employees")]
        public IEnumerable<EmployeeV2Model> Get()
        {
            return employees;
        }
        [Route("api/v2/employees/{id}")]
        public EmployeeV2Model Get(int id)
        {
            return employees.FirstOrDefault(s => s.EmployeeID == id);
        }
    }
}