using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiDemo.Migrations
{
    public partial class SalaryTableFixingConventionV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salary_Employees_EmployeesId",
                table: "Salary");

            migrationBuilder.DropIndex(
                name: "IX_Salary_EmployeesId",
                table: "Salary");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "Salary");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Salary",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Salary_EmployeeId",
                table: "Salary",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Salary_Employees_EmployeeId",
                table: "Salary",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salary_Employees_EmployeeId",
                table: "Salary");

            migrationBuilder.DropIndex(
                name: "IX_Salary_EmployeeId",
                table: "Salary");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Salary");

            migrationBuilder.AddColumn<int>(
                name: "EmployeesId",
                table: "Salary",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salary_EmployeesId",
                table: "Salary",
                column: "EmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salary_Employees_EmployeesId",
                table: "Salary",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
