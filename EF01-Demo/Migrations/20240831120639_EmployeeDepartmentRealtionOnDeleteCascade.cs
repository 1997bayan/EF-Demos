using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF01_Demo.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeDepartmentRealtionOnDeleteCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDataAnnotation_departments_DepartmentDeptID",
                table: "EmployeeDataAnnotation");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDataAnnotation_departments_DepartmentDeptID",
                table: "EmployeeDataAnnotation",
                column: "DepartmentDeptID",
                principalTable: "departments",
                principalColumn: "DeptID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDataAnnotation_departments_DepartmentDeptID",
                table: "EmployeeDataAnnotation");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDataAnnotation_departments_DepartmentDeptID",
                table: "EmployeeDataAnnotation",
                column: "DepartmentDeptID",
                principalTable: "departments",
                principalColumn: "DeptID");
        }
    }
}
