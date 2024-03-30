using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB03_TINOCO_DAEA
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Student (int studentId, string firstName, string lastName)
        {
            this.StudentId = studentId;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
