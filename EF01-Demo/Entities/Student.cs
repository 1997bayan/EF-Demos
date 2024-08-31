using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF01_Demo.Entities
{
    internal class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }

        // Many relation
        // public ICollection<Course> Courses { get; set; } = new HashSet<Course>();


        // one to many : Student and studentCourse table 
        public ICollection<StudentCousre> StudentCourses { get; set; } = new HashSet<StudentCousre>();
    }
}
