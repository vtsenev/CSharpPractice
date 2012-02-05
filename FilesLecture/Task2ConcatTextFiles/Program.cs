using System;
using System.IO;

namespace Task2ConcatTextFiles
{
    class Program
    {
        const string FILE1 = @"..\..\file1.txt";
        const string FILE2 = @"..\..\file2.txt";
        const string NEWFILE = @"..\..\new_file.txt";

        static void Main(string[] args)
        {
            // Task 2: Write a program that concatenates two text
            // files into another text file.

            string file1Contents, file2Contents;

            using (StreamReader reader1 = new StreamReader(FILE1))
            using (StreamReader reader2 = new StreamReader(FILE2))
            {
                file1Contents = reader1.ReadToEnd();
                file2Contents = reader2.ReadToEnd();
            }

            using (StreamWriter writer = new StreamWriter(NEWFILE))
            {
                writer.WriteLine(file1Contents);
                writer.WriteLine(file2Contents);
                writer.Flush();
            }
        }
    }
}
