using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using WebApiDemo.Models;
using WebApiDemo.Models.DTO.EmployeeDTO;
using WebApiDemo.Services.Interfaces;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService service;
        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employees = service.GetAll();
                if (employees == null) return NotFound();
                return Ok(employees);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("id")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var employee = service.Get(id);
                if (employee == null) return NotFound();
                return Ok(employee);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("company/id")]
        public IActionResult GetEmployeeByCompany(int id)
        {
            try
            {
                var employees = service.GetEmployeesByCompanyId(id);
                if (employees == null) return NotFound();
                return Ok(employees);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateEmployee(CreateEmployeeDto employee)
        {
            try
            {
                Employees output = new Employees
                {
                    Name = employee.Name,
                    LastName = employee.LastName,
                    CompanyID = employee.CompanyId
                };

                service.Create(output);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var employee = service.Get(id);
                if (employee == null)
                {
                    return NotFound();
                }
                else
                {
                    service.Delete(id);
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateEmployee(UpdateEmployeeDto employee)
        {
            try
            {
                Employees model = new Employees 
                { 
                    Id = employee.Id,
                    Name = employee.Name,
                    LastName = employee.LastName,
                    CompanyID = employee.CompanyId
                };

                var output = service.Update(model);

                if (output == null) return NotFound();
                return Ok(output);

            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

    }
}
