using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3SortStudentsLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 3: Write a method that from a given array of students
            // finds all students whose first name is before its last name
            // alphabetically. Use LINQ query operators.

            Student[] arrOfStudents = { new Student("Pesho", "Goshov"), new Student("Aaov", "Ceco") };
            var students = FindStudents(arrOfStudents);
            foreach (Student st in students)
            {
                Console.WriteLine(st.FirstName + " " + st.LastName);
            }
        }

        static List<Student> FindStudents(Student[] students)
        {
            var stQuery =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;
            return stQuery.ToList();
        }
    }

    class Student
    {
        private string firstName;
        private string lastName;

        public string FirstName
        {
            get { return this.firstName; }
        }

        public string LastName
        {
            get { return this.lastName; }
        }

        public Student(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
