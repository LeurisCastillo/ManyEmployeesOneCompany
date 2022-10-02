namespace WebApiDemo.Models.DTO.EmployeeDTO
{
    public class UpdateEmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? CompanyId { get; set; }
    }
}
