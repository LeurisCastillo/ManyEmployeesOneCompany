using System.Collections.Generic;
using WebApiDemo.Models;

namespace WebApiDemo.Services.Interfaces
{
    public interface IEmployeeService : ICrud<Employees>
    {
        List<Employees> GetEmployeesByCompanyId(int companyId);
    }
}
