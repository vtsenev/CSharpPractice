using System;
using System.IO;
using System.Text;

namespace Task3ReadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 3: Write a program that enters file name along with
            // its full file path (e.g. C:\WINDOWS\win.ini), reads its
            // contents and prints it on the console. Find in MSDN how 
            // to use System.IO.File.ReadAllText(…). Be sure to catch all
            // possible exceptions and print user-friendly error messages.

            Console.WriteLine("Enter full file path:");
            string filepath = Console.ReadLine();
            
            try
            {
                string text = System.IO.File.ReadAllText(filepath);
                Console.WriteLine("--START OF FILE--");
                Console.WriteLine(text);
                Console.WriteLine("--END OF FILE--");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
            catch (FileLoadException)
            {
                Console.WriteLine("File load error.");
            }
        }
    }
}
