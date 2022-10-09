using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiDemo.Models;
using WebApiDemo.Services.Interfaces;

namespace WebApiDemo.Services
{
    public class SalaryService : ISalaryService
    {
        private DataContext db;

        public SalaryService(DataContext db)
        {
            this.db = db;
        }

        public void Create(Salary entity)
        {
            try
            {
                db.Add(entity);
                db.SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                Salary salary = Get(id);
                if (salary != null)
                {
                    db.Remove(salary);
                    db.SaveChanges();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public Salary Get(int id)
        {
            Salary salary;
            try
            {
                salary = db.Set<Salary>().Where(s => s.EmployeeId == id)
                    .Include(s => s.Employee)
                    .FirstOrDefault();
            }
            catch (System.Exception)
            {
                throw;
            }

            return salary;
        }

        public List<Salary> GetAll()
        {
            List<Salary> salaries;
            try
            {
                salaries = db.Set<Salary>().ToList();
            }
            catch (System.Exception)
            {
                throw;
            }

            return salaries;
        }

        public Salary Update(Salary entity)
        {
            try
            {
                Salary salary = Get(entity.Id);
                if (salary != null)
                {
                    salary.Wages = entity.Wages;
                    salary.EmployeeId = entity.EmployeeId;
                    db.Update(salary);
                    db.SaveChanges();
                }

                return salary;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
