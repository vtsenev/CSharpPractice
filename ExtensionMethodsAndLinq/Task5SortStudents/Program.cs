using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task5SortStudents
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 5: Using the extension methods OrderBy() and ThenBy()
            // with lambda expressions sort the students by first name and
            // last name in descending order. Rewrite the same with LINQ.

            Student[] students = { new Student("Vlado", "Pashov", 25),
                                   new Student("Pesho", "Vasilev", 20),
                                   new Student("Anton", "Genov", 17),
                                   new Student("Anton", "Tsenev", 22),
                                   new Student("Vlado", "Tsenev", 27) };

            var ordered = students.OrderStudents();
            foreach (Student student in ordered)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }

            Console.WriteLine();
            Console.WriteLine();
            var orderedLINQ = students.OrderStLINQ();
            foreach (Student student in orderedLINQ)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }
    }

    static class Extension
    {
        public static List<Student> OrderStudents(this Student[] students)
        {
            return students.OrderByDescending(st => st.FirstName).ThenByDescending(st => st.LastName).ToList();
        }

        public static List<Student> OrderStLINQ(this Student[] students)
        {
            var ordered =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;
            return ordered.ToList();
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
