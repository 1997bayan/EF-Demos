using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF01_Demo.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentForgineKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDataAnnotation_departments_DepartmentDeptID",
                table: "EmployeeDataAnnotation");

            migrationBuilder.RenameColumn(
                name: "DepartmentDeptID",
                table: "EmployeeDataAnnotation",
                newName: "DepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDataAnnotation_DepartmentDeptID",
                table: "EmployeeDataAnnotation",
                newName: "IX_EmployeeDataAnnotation_DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDataAnnotation_departments_DepartmentID",
                table: "EmployeeDataAnnotation",
                column: "DepartmentID",
                principalTable: "departments",
                principalColumn: "DeptID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDataAnnotation_departments_DepartmentID",
                table: "EmployeeDataAnnotation");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "EmployeeDataAnnotation",
                newName: "DepartmentDeptID");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeDataAnnotation_DepartmentID",
                table: "EmployeeDataAnnotation",
                newName: "IX_EmployeeDataAnnotation_DepartmentDeptID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDataAnnotation_departments_DepartmentDeptID",
                table: "EmployeeDataAnnotation",
                column: "DepartmentDeptID",
                principalTable: "departments",
                principalColumn: "DeptID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
