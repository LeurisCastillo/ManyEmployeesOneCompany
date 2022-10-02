using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiDemo.Migrations
{
    public partial class companyEmployeeIdRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "Company");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeesId",
                table: "Company",
                type: "int",
                nullable: true);
        }
    }
}
