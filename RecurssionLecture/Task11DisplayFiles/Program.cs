using System;
using System.IO;

namespace Task11DisplayFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 11: Write a recursive program that traverses the entire hard disk drive
            // C:\ and displays all folders recursively and all files inside each of them.

            string path = @"C:\Windows";
            TraverseDirs(new DirectoryInfo(path));
        }

        static void TraverseDirs(DirectoryInfo dir)
        {
            // Subdirs
            try         // Avoid errors such as "Access Denied"
            {
                foreach (DirectoryInfo iInfo in dir.GetDirectories())
                {
                    Console.WriteLine("Found dir:  " + iInfo.FullName);
                    TraverseDirs(iInfo);
                }
            }
            catch (Exception)
            {
            }

            // Subfiles
            try         // Avoid errors such as "Access Denied"
            {
                foreach (FileInfo iInfo in dir.GetFiles())
                {
                    Console.WriteLine("Found file: " + iInfo.FullName);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
