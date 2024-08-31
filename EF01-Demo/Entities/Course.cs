using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF01_Demo.Entities
{
    internal class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }

        // Many relation by convention 
        //public ICollection<Student> Students { get; set; } = new HashSet<Student>();

        // one to many : Course and studentCourse table 

        //navigation property
        public ICollection<StudentCousre> CourseStudents { get; set; } = new HashSet<StudentCousre>(); 

    }
}
