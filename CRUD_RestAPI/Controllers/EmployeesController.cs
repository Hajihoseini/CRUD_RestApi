using CRUD_RestAPI.EmployeeData;
using CRUD_RestAPI.Modeld;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_RestAPI.Controllers
{

    [ApiController]
    public class EmployeesController : Controller
    {
        private IEmployee _employee;
        public EmployeesController(IEmployee employee )
        {
            _employee = employee;
        }



        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployee()
        {
            return Ok(_employee.GetEmployees());    
        }



        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employee.GetEmployee(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound($"This employee with id =  {id}  was not found !");
        }


        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetEmployee(Employee employee)
        {
            _employee.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path
                +"/" + employee.Id,employee);
        }


        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employee.GetEmployee(id);
            if(employee != null)
            {
                _employee.DeleteEmployee(employee);
                return Ok();
            }
            return NotFound($"This employee with id =  {id}  was not found !");
        }


        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditEmployee(Guid id , Employee employee)
        {
            var existedEmployee = _employee.GetEmployee(id);
            if (existedEmployee != null)
            {
                employee.Id = existedEmployee.Id;
                _employee.EditEmployee(employee);
                return Ok();
            }
            return Ok(employee);
        }
    }
}
