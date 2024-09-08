using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF01_Demo.Entities
{    // Poco class
     // Plain old CLR object : there is no buissness or functionality in this class just properties
     //
     // EF Core support 4 ways for MAPPING  classes => Db"DataBase Object" (Table , View , Functions , Sp)
     // First To table
     // 1. By convention (Default Behaviou)
     //   ممكن استخدم الاربع طرق سوا لا يتعارضوا 
     //

    public class Employee 
    {
        public int Id { get; set; } // to set automatic primary key it should be : public numeric named as "Id" or "EmployeeId"
        public string EmpName { get; set; } // string Reference Type : dosnt Allow null , "nvarchar(max)"
        //public string EmpName { get; set; }
        // put ? (nullable string ) to make the name in table allow null
        // Change Name to EmpName So we need to add Migration =>  PM> Add-Migration "RenameEmpName"
        public double Salary { get; set; } /// <summary> Value Type : dont allow null (Required)
        /// </summary>
        public int? Age { get; set; } // nullable int : Allow null(Optional)
        public string? Adress { get; set; }

    }
}
