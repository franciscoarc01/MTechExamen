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
            return new List<Employee>();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return null;
        }

        // GET api/<EmployeeController>/name
        [HttpGet("{name}")]
        public IEnumerable<Employee> Get(string name)
        {
            return new List<Employee>();
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public bool Post([FromBody] Employee employee)
        {
            return true;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee employee)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return true;
        }
    }
}
