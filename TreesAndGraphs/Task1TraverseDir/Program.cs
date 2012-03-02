using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Task1TraverseDir
{
    class Program
    {
        // Task 1: Write a program to traverse the directory C:\WINDOWS
        // and all its subdirectories recursively and to display all
        // files matching the mask *.exe. Use the class System.IO.Directory.

        static void Main(string[] args)
        {
            DirectoryInfo root = new DirectoryInfo(@"C:\Windows\");
            TraverseDirs(root);
        }

        static void TraverseDirs(DirectoryInfo dir)
        {
            try
            {
                foreach (DirectoryInfo subdir in dir.GetDirectories())
                {
                    TraverseDirs(subdir);
                }
            }
            catch
            {
            }

            try
            {
                foreach (FileInfo file in dir.GetFiles("*.exe"))
                {
                    Console.WriteLine(file.FullName);
                }
            }
            catch
            {
            }
        }
    }
}
