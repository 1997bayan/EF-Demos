using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF01_Demo.Entities
{
    public class Department
    {
        public int DeptID { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfCreation { get; set; }

        //you should initialize the Employess reference here or through constructor.

        // If there are more than one relationship between the same two entity:what we do ?
        [InverseProperty("Department")]
        public virtual ICollection<EmployeeDataAnnotation> Employess { get; set; } = new HashSet<EmployeeDataAnnotation>();
        //Navigational property => Many 
        // why its type ICollection ?


    }
}
