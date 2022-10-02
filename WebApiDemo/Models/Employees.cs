using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? CompanyID { get; set; }
        public Company Company { get; set; }
    }
}
