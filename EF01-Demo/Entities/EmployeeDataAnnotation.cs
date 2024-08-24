﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF01_Demo.Entities
{
    internal class EmployeeDataAnnotation
    {
            [Key] // To define that EmpId is a primary key
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]// to add identity with default (1,1)
            public int EmpId { get; set; }
            [Required] // => dont allow null
            [Column(TypeName = "varchar")] //varchar(max)
                                           //[MaxLength(50)] Or use:
            [StringLength(50 , MinimumLength = 10)] // MinimumLength => لن تتحول في الداتا بيس مجرد فرونت اند فالديشن
        public string Name { get; set; }
               // [Column (TypeName = "Money")] 
               //OR
                [DataType (DataType.Currency)] // Enum
            public decimal Salary { get; set; }
             [Range (22,60)] // Front end validation
            public int? Age { get; set; }

              //  [DataType(DataType.EmailAddress)]
            //Or use
            [EmailAddress]
            public string? Email { get; set; }
       // [DataType(DataType.PhoneNumber)]
        [Phone]
        public string  PhoneNumber { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        // then add migration

    }
}