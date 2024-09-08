using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF01_Demo.Migrations
{
    /// <inheritdoc />
    public partial class RunSqlScriptForCreatingView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           // @ for orgnization 
            migrationBuilder.Sql(@"create view EmployeeDepartmentView
                                with Encryption
                                As 
	                                select E.EmpId EmployeeId , E.Name EmployeeName , D.DeptID DeptId , D.DeptName DeptName
	                                from departments D , EmployeeDataAnnotation E
	                                where D.DeptID = E.DepartmentID");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("drop view EmployeeDepartmentView"); 

        }
    }
}
