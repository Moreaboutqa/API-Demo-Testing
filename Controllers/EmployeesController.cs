using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public List<Employee> Employees = new List<Employee> 
        { 
          new Employee { Id = 1,Name="Mary", City="Johnstown", Address="123 Main Street, Apt 4B, Springfield, IL 62701", Region="Midwest"},
          new Employee { Id = 2,Name="John", City="Marysville", Address="456 Oak Avenue, Suite 201, Lakeside, CA 92040", Region="Pacific Northwest"},
          new Employee { Id = 3,Name="James", City="Jamestown", Address="789 Maple Lane, Unit 12, Elmwood Park, NJ 07407", Region="Southeast"},
          new Employee { Id = 4,Name="Jennifer", City="Jenison", Address="101 Pine Road, Lot 7, Cedar Rapids, IA 52402", Region="Southwest"},
          new Employee { Id = 5,Name="Robert", City="Robertsdale", Address="321 Elm Street, Building C, Boulder, CO 80301", Region="Northeast"},
        };

        [HttpGet("GetAllEmployees")]
        public IActionResult GetAll()
        {
            return Ok(Employees);
        }
        [HttpGet("Get/{id:int}")]
        public IActionResult Get(int id)
        {
            var emp= Employees.FirstOrDefault(x => x.Id == id);
            if(emp == null)
            {
                return NotFound("employee not found");
            }
            return Ok(emp);
        }

        [HttpPost("AddEmployee")]
        public IActionResult Add(Employee employee)
        {
            Employees.Add(employee);
            return Created("",Employees);
        }
        [HttpPut("UpdateEmployee")]
        public IActionResult Update(Employee employee)
        {
            var emp = Employees.FirstOrDefault(x => x.Id == employee.Id);
            if(emp != null)
            {
                emp.Name = employee.Name;
                emp.City = employee.City;
                emp.Address = employee.Address;
                emp.Region=employee.Region;
            }
            else
            {
                return NotFound("employee not found");
            }
            return Ok(Employees);
        }

        [HttpDelete("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var emp = Employees.FirstOrDefault(x => x.Id == id);
            if(emp != null)
            {
                Employees.Remove(emp);
            }
            else
            {
                return NotFound("employee not found");
            }
            return Ok(Employees);
        }
    }
}
