using System;
using System.Collections.Generic;
using System.Linq;
using WebApiDemo.Models;
using WebApiDemo.Services.Interfaces;

namespace WebApiDemo.Services
{
    public class EmployeeService : IEmployeeService
    {
        private DataContext db;

        public EmployeeService(DataContext db)
        {
            this.db = db;
        }

        public void Create(Employees entity)
        {
            try
            {
                db.Add<Employees>(entity);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                Employees employee = Get(id);
                if(employee != null)
                {
                    db.Remove<Employees>(employee);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Employees Get(int id)
        {
            Employees employee;

            try
            {
                employee = db.Find<Employees>(id);
            }
            catch (Exception)
            {
                throw;
            }

            return employee;
        }

        public List<Employees> GetAll()
        {

            List<Employees> employees;

            try
            {
                employees = db.Set<Employees>().ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return employees;
        }

        public List<Employees> GetEmployeesByCompanyId(int companyId)
        {
            List<Employees> employees;

            try
            {
                employees = db.Set<Employees>().Where(e => e.CompanyID == companyId).ToList();
            }
            catch (Exception)
            {
                throw;
            }

            return employees;
        }

        public Employees Update(Employees entity)
        {
            try
            {
                Employees employee = Get(entity.Id);
                if (employee != null)
                {
                    employee.Name = entity.Name;
                    employee.LastName = entity.LastName;
                    employee.CompanyID = entity.CompanyID;
                    db.Update<Employees>(employee);
                    db.SaveChanges();
                }

                return employee;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
