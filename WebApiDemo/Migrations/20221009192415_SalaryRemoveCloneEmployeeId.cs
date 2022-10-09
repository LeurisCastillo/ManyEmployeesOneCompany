using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiDemo.Migrations
{
    public partial class SalaryRemoveCloneEmployeeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Salary");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Salary",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
