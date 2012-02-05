using System;
using System.IO;

namespace Task4CompareFiles
{
    class Program
    {
        const string FILE1 = @"..\..\file1.txt";
        const string FILE2 = @"..\..\file2.txt";

        static void Main(string[] args)
        {
            // Task 4: Write a program that compares two text files
            // line by line and prints the number of lines that are
            // the same and the number of lines that are different.
            // Assume the files have equal number of lines.

            using (StreamReader reader1 = new StreamReader(FILE1))
            using (StreamReader reader2 = new StreamReader(FILE2))
            {
                string lineFromFile1 = reader1.ReadLine();
                string lineFromFile2 = reader2.ReadLine();

                int equalLines = 0;
                int differentLines = 0;

                while (lineFromFile1 != null || lineFromFile2 != null)
                {
                    if (String.Compare(lineFromFile1, lineFromFile2) == 0)
                    {
                        equalLines++;
                    }
                    else
                    {
                        differentLines++;
                    }
                    lineFromFile1 = reader1.ReadLine();
                    lineFromFile2 = reader2.ReadLine();
                }

                Console.WriteLine("Lines that are the same: {0}.", equalLines);
                Console.WriteLine("Lines that are different: {0}.", differentLines);
            }
        }
    }
}
