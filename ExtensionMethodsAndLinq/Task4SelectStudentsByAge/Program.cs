using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task4SelectStudentsByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 4: Write a LINQ query that finds the first name and
            // last name of all students with age between 18 and 24.

            Student[] students = { new Student("Vlado", "Pashov", 25),
                                   new Student("Pesho", "Vasilev", 20),
                                   new Student("Anton", "Genov", 17) };

            var youngStudents =
                from student in students
                where student.Age > 17 && student.Age < 25
                select student;

            foreach (Student student in youngStudents)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + " " + student.Age);
            }
        }
    }

    class Student
    {
        private string firstName;
        private string lastName;
        private int age;

        public string FirstName
        {
            get { return this.firstName; }
        }

        public string LastName
        {
            get { return this.lastName; }
        }

        public int Age
        {
            get { return this.age; }
        }

        public Student(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }
    }
}
