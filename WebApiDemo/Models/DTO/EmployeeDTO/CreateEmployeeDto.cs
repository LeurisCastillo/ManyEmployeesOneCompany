namespace WebApiDemo.Models.DTO.EmployeeDTO
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? CompanyId { get; set; }
    }
}
