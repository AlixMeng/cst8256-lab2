using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_2.Classes
{
    public class Student
    {
        public string Id { get; }

        public string Name { get; }

        public int Grade { get; }

        public Student(string id, string name, int grade)
        {
            Id = id;
            Name = name;
            Grade = grade;
        }
    }
}