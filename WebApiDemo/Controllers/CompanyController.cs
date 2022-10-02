using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiDemo.Models;
using WebApiDemo.Models.DTO.CompanyDTO;
using WebApiDemo.Services.Interfaces;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICompanyService service;

        public CompanyController(ICompanyService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult GetAllCompanies()
        {
            List<Company> companies;
            try
            {
                companies = service.GetAll();
                if (companies == null) return NotFound();
                return Ok(companies);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCompanyById(int id)
        {
            Company company;
            try
            {
                company = service.Get(id);
                if (company == null) return NotFound();
                return Ok(company);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateCompany(CreateCompanyDto company)
        {
            try
            {
                Company output = new Company
                {
                    Name = company.Name
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
        public IActionResult UpdateCompany(UpdateCompanyDto company)
        {
            try
            {
                Company model = new Company
                {
                    Id = company.Id,
                    Name = company.Name,
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

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteCompany(int id)
        {
            try
            {
                var company = service.Get(id);
                if (company == null) 
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
