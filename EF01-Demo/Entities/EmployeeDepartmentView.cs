using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF01_Demo.Entities
{
    public class EmployeeDepartmentView
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int DeptId { get; set; }
        public string DeptName { get; set; }
    }
}
