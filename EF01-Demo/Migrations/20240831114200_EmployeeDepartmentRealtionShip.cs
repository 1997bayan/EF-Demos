using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF01_Demo.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeDepartmentRealtionShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentDeptID",
                table: "EmployeeDataAnnotation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDataAnnotation_DepartmentDeptID",
                table: "EmployeeDataAnnotation",
                column: "DepartmentDeptID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDataAnnotation_departments_DepartmentDeptID",
                table: "EmployeeDataAnnotation",
                column: "DepartmentDeptID",
                principalTable: "departments",
                principalColumn: "DeptID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDataAnnotation_departments_DepartmentDeptID",
                table: "EmployeeDataAnnotation");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDataAnnotation_DepartmentDeptID",
                table: "EmployeeDataAnnotation");

            migrationBuilder.DropColumn(
                name: "DepartmentDeptID",
                table: "EmployeeDataAnnotation");
        }
    }
}
