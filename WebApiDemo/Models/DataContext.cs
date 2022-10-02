using Microsoft.EntityFrameworkCore;

namespace WebApiDemo.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) 
        {
        }
        
        DbSet<Employees> Employees { get; set; }
        DbSet<Company> Company { get; set; }
    }
}
