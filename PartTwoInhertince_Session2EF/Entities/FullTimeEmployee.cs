 using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PartTwoInhertince_Session2EF.Entities
{
    internal class FullTimeEmployee : Employee
    {
        public decimal Salary { get; set; }
        public DateTime  StartDate { get; set; }
    }
}
