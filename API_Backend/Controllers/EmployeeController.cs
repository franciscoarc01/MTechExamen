using API_Backend.Handler;
using API_Backend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return EmployeeHandler.Employees();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(string id)
        {
            Employee employee = EmployeeHandler.FindEmployee(id);
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // GET api/<EmployeeController>/name
        [HttpGet("{name}")]
        public IEnumerable<Employee> GetByName(string name)
        {
            return EmployeeHandler.FindEmployeeByNames(name);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] Employee employee)
        {
            bool result = EmployeeHandler.InsertEmployee(employee);
            return result ? Ok(result) : BadRequest();
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public ActionResult<Employee> Put(string id, [FromBody] Employee employee)
        {
            try
            {
                EmployeeHandler.UpdateEmployee(id, employee);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(string id)
        {
            bool result = EmployeeHandler.DeleteEmployee(id);
            return result ? Ok(result) : BadRequest();
        }
    }
}
