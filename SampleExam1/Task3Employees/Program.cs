using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Task3Employees
{
    class Program
    {
        static List<Employee> employees = new List<Employee>();
        static Dictionary<string, int> positionToRank = new Dictionary<string, int>();
        static List<KeyValuePair<string, int>> posToRank = new List<KeyValuePair<string,int>>();
        const string INPUT = @"..\..\test.020.in.txt";
        const string OUTPUT = @"..\..\test.out.txt";

        static void Main(string[] args)
        {
            Input();
            //InputFile();
            Sort();
            Print();
        }

        static void Input()
        {
            // read N - number of positions
            string input = Console.ReadLine();
            int n = int.Parse(input);

            // read all job titles with their ratings
            for (int pos = 0; pos < n; pos++)
            {
                input = Console.ReadLine();
                string[] lineData = input.Split('-');
                string jobTitle = lineData[0].Trim();
                string jobRating = lineData[1].Trim();
                posToRank.Add(new KeyValuePair<string,int>(jobTitle, int.Parse(jobRating)));
                //positionToRank.Add(jobTitle, int.Parse(jobRating));
            }

            // read M - number of employees
            input = Console.ReadLine();
            int m = int.Parse(input);

            // read all employee names and corresponding positions
            for (int counter = 0; counter < m; counter++)
            {
                input = Console.ReadLine();
                string[] lineData = input.Split('-');
                string employeeName = lineData[0].Trim();
                string position = lineData[1].Trim();
                //Employee employee = new Employee(employeeName, position, positionToRank[position]);
                KeyValuePair<string, int> pair = posToRank.First(a => a.Key == position);
                Employee employee = new Employee(employeeName, position, pair.Value);
                employees.Add(employee);
            }
        }

        static void InputFile()
        {
            StreamReader reader = new StreamReader(INPUT);
            using (reader)
            {
                string input = reader.ReadLine();
                int n = int.Parse(input);

                for (int i = 0; i < n; i++)
                {
                    input = reader.ReadLine();
                    string[] lineData = input.Split('-');
                    string jobTitle = lineData[0].Trim();
                    string jobRating = lineData[1].Trim();
                    posToRank.Add(new KeyValuePair<string, int>(jobTitle, int.Parse(jobRating)));
                    //positionToRank.Add(jobTitle, int.Parse(jobRating));
                }

                input = reader.ReadLine();
                int m = int.Parse(input);

                for (int counter = 0; counter < m; counter++)
                {
                    input = reader.ReadLine();
                    string[] lineData = input.Split('-');
                    string employeeName = lineData[0].Trim();
                    string position = lineData[1].Trim();
                    KeyValuePair<string, int> pair = posToRank.First(a => a.Key == position);
                    //Employee employee = new Employee(employeeName, position, positionToRank[position]);
                    Employee employee = new Employee(employeeName, position, pair.Value);
                    employees.Add(employee);
                }
            }
        }

        static void Sort()
        {
            SortEmployees sorter = new SortEmployees();
            employees.Sort(sorter);
        }

        static void Print()
        {
            foreach (Employee e in employees)
            {
                Console.WriteLine(e.FirstName + " " + e.LastName);
            }
            //StreamWriter writer = new StreamWriter(OUTPUT);
            //using (writer)
            //{
            //    foreach (Employee e in employees)
            //    {
            //        writer.WriteLine(e.FirstName + " " + e.LastName);
            //    }
            //}
        }
    }

    class SortEmployees : IComparer<Employee>
    {
        public int Compare(Employee a, Employee b)
        {
            if (a.Rank > b.Rank)
            {
                return -1;
            }
            else if (a.Rank == b.Rank)
            {
                if (b.LastName.CompareTo(a.LastName) == 0)
                {
                    return b.FirstName.CompareTo(a.FirstName) * (-1);
                }
                else
                {
                    return b.LastName.CompareTo(a.LastName) * (-1);
                }
            }
            else
            {
                return 1;
            }
        }
    }

    class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int Rank { get; set; }

        public Employee(string name, string position, int rank)
        {
            this.Position = position;
            this.Rank = rank;

            string[] names = name.Split(' ');
            this.FirstName = names[0];
            this.LastName = names[1];
        }
    }
}
