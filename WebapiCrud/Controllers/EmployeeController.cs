using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebapiCrud.Model;

namespace WebapiCrud.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            //var t = new GetAllEmployees();
            //return new string[] { "value1", "value2" };
            EmployeeDataAccessLayer employeeDataAccessLayers = new EmployeeDataAccessLayer();
            return employeeDataAccessLayers.GetAllEmployees();

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            EmployeeDataAccessLayer employeeDataAccessLayers = new EmployeeDataAccessLayer();
            var employee = employeeDataAccessLayers.GetEmployeeData(id);
            return employee;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Employee employee)
        {
            EmployeeDataAccessLayer employeeDataAccessLayers = new EmployeeDataAccessLayer();
            employeeDataAccessLayers.AddEmployee(employee);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Employee employee)
        {
            if (id != employee.ID)
            {
                return BadRequest();
            }
            EmployeeDataAccessLayer employeeDataAccessLayers = new EmployeeDataAccessLayer();
            employeeDataAccessLayers.UpdateEmployee(employee);
            return Ok();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            EmployeeDataAccessLayer employeeDataAccessLayers = new EmployeeDataAccessLayer();
            employeeDataAccessLayers.DeleteEmployee(id);
            return Ok();
        }
    }
}
