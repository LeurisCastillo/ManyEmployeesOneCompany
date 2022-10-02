using NPOI.HSSF.Record;
using System.Collections.Generic;
using System.Linq;
using WebApiDemo.Models;
using WebApiDemo.Services.Interfaces;

namespace WebApiDemo.Services
{
    public class CompanyService : ICompanyService
    {
        private DataContext db;

        public CompanyService(DataContext db)
        {
            this.db = db;
        }

        public void Create(Company entity)
        {
            try
            {
                db.Add<Company>(entity);
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
                Company company = Get(id);
                if (company != null)
                {
                    db.Remove<Company>(company);
                    db.SaveChanges();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public Company Get(int id)
        {
            Company company;
            try
            {
                company = db.Find<Company>(id);
            }
            catch (System.Exception)
            {
                throw;
            }

            return company;
        }

        public List<Company> GetAll()
        {
            List<Company> companies;
            try
            {
                companies = db.Set<Company>().ToList();
            }
            catch (System.Exception)
            {
                throw;
            }

            return companies;
        }

        public Company Update(Company entity)
        {
            try
            {
                Company company = Get(entity.Id);
                if (company != null)
                {
                    company.Name = entity.Name;
                    db.Update<Company>(company);
                    db.SaveChanges();
                }

                return company;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
