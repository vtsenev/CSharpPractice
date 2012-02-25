using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task11StudentQueue
{
    class Program
    {
        static string[] names = { "Pesho", "Gosho", "Ceco", "Mimi", "Valio", "Ivan", "Krasi", "Ivo", "Rosi", "Stefan" };

        static void Main(string[] args)
        {
            // Task 11: Write a class Student, that has three fields: name (String), age(Integer) and paidSemesterOnline(Boolean).
            // When in a queue the students who paid online are with higher priority than those who are about to pay the semester.
            // Write a program which, given a queue of students, determines whose turn it is. Hint: use priority queue.

            PriorityQueue pqueue = new PriorityQueue();
            for (int i = 1; i <= 10; i++)
            {
                Random r = new Random();
                bool paidOnline;
                int priority;
                
                // let's assume every 4th student has paid online (Mimi and Ivo in this case)
                if (i % 4 == 0)
                {
                    paidOnline = true;
                    priority = 1;
                }
                else
                {
                    paidOnline = false;
                    priority = 10;
                }

                Student student = new Student(names[i - 1], r.Next(18, 120), paidOnline);
                pqueue.Enqueue(priority, student);
            }

            while (!pqueue.IsEmpty)
            {
                Student student = pqueue.Dequeue();
                Console.WriteLine(student);
            }
        }
    }

    class Student
    {
        private string name;
        private int age;
        private bool paidSemesterOnline;

        public Student(string name, int age, bool paidSemesterOnline)
        {
            this.name = name;
            this.age = age;
            this.paidSemesterOnline = paidSemesterOnline;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public bool PaidSemesterOnline
        {
            get { return this.paidSemesterOnline; }
            set { this.paidSemesterOnline = value; }
        }

        public override string ToString()
        {
            if (paidSemesterOnline)
            {
                return name + "(" + age + ") paid his semester online.";
            }
            else
            {
                return name + "(" + age + ") didn't pay online.";
            }
        }
    }

    class PriorityQueue
    {
        private SortedDictionary<int, Queue<Student>> list = new SortedDictionary<int, Queue<Student>>();

        public void Enqueue(int priority, Student value)
        {
            Queue<Student> q;
            if (!list.TryGetValue(priority, out q))
            {
                q = new Queue<Student>();
                list.Add(priority, q);
            }
            q.Enqueue(value);
        }

        public Student Dequeue()
        {
            var pair = list.First();
            var value = pair.Value.Dequeue();
            if (pair.Value.Count == 0)
                list.Remove(pair.Key);

            return value;
        }

        public bool IsEmpty
        {
            get { return !list.Any(); }
        }
    }
}
