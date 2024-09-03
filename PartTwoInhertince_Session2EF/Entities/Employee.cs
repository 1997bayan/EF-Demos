using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTwoInhertince_Session2EF.Entities
{
    //Employee class is just container
    //abstract : avoid create object of Employee
    internal abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public  int? Age  { get; set; }
        public string Address { get; set; }




    }
}
