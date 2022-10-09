using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;
using WebApiDemo.Models.DTO.SalaryDTO;
using WebApiDemo.Services.Interfaces;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private ISalaryService service;

        public SalaryController(ISalaryService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetSalaries()
        {
            try
            {
                var salaries = service.GetAll();
                if (salaries == null) return NotFound();
                return Ok(salaries);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
            
        }
        // Get the salary base on the employee id
        [HttpGet("{id}")]
        public IActionResult GetSalaryOfEmployee(int id)
        {
            try
            {
                var salary = service.Get(id);
                if (salary == null) return NotFound();
                return Ok(salary);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(CreateSalaryDTO salary)
        {
            try
            {
                Salary output = new Salary
                {
                    Wages = salary.Wages,
                    EmployeeId = salary.EmployeeID,
                };

                service.Create(output);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Update(UpdateSalaryDTO salary)
        {
            try
            {
                Salary model = new Salary
                {
                    Id = salary.Id,
                    Wages = salary.Wages,
                    EmployeeId = salary.EmployeeID,
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

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var salary = service.Get(id);
                if (salary == null)
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
    }
}
