using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApiDemo.Models
{
    public class Salary
    {
        [Key]
        public int Id { get; set; }
        public int Wages { get; set; }
        public int EmployeeId { get; set; }
        [JsonIgnore] // con esta linea puedes corregir el error del bucle de json infinito
        public Employees Employee { get; set; }
    }
}
