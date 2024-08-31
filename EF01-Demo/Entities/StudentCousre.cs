﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF01_Demo.Entities
{
    internal class StudentCousre
    {
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public int Grade { get; set; }

        // one to many : Student and studentCourse table

        public Student  Student { get; set; }

        // one to many : Course and studentCourse table
        public Course Course { get; set; }


    }
}