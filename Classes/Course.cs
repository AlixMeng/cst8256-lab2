using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_2.Classes
{
    public class Course
    {
        public string Number { get; private set; }

        public string Name { get; private set; }

        public Course(string courseNumber, string courseName)
        {
            Number = courseNumber;
            Name = courseName;
        }

        private List<Student> StudentList = new List<Student>();

        public void addStudent(Student student)
        {
            StudentList.Add(student);
        }

        public List<Student> GetStudentList()
        {
            return StudentList;
        }

        public override string ToString()
        {
            return Number + " " + Name;
        }
    }
}