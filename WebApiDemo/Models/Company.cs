using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employees> Employees { get; set; }
    }
}
