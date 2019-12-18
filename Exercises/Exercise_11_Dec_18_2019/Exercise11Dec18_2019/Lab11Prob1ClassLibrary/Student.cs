using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab11Prob1ClassLibrary
{
    [Serializable]
    public class Student
    {
        public readonly string ID;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseName { get; set; }
        public int  Grade { get; set; }

        public Student(string id, string firstName, string lastName, string courseName, int grade)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            CourseName = courseName;
            Grade = grade;
        }

        public Student() : this(string.Empty, string.Empty, string.Empty, string.Empty, 0) //what does this line do

        {

        }

        public Student(Student stud) : this(stud.ID, stud.FirstName, stud.LastName, stud.CourseName, stud.Grade)

        {

        }

        public override string ToString()
        {
            return string.Join(", ", ID, FirstName, LastName, CourseName);
        }
    }
}
