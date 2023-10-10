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
          new Employee { Id = 1,Name="Ali"},
          new Employee { Id = 2,Name="Kamran"}
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
