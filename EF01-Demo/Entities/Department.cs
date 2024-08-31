using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF01_Demo.Entities
{
    internal class Department
    {
        public int DeptID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }

        //you should initialize the Employess reference here or through constructor.

        public ICollection<EmployeeDataAnnotation> Employess { get; set; } = new HashSet<EmployeeDataAnnotation>();
        //Navigational property => Many 
        // why its type ICollection ?


    }
}
