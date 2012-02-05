using System;
using System.IO;

namespace Task1ReadAndPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1: Write a program that reads a text
            // file and prints on the console its odd lines.

            string pathfilename = @"..\..\textfile.txt";
            Console.WriteLine("File {0} contents:", pathfilename);
            Console.WriteLine(new string('-', 40));
            StreamReader reader = new StreamReader(pathfilename);
            try
            {
                using (reader)
                {
                    string fileContents = reader.ReadToEnd();
                    Console.WriteLine(fileContents);
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File {0} is not found!", e.FileName);
            }
            catch
            {
                Console.WriteLine("Fatal error occured.");
            }
            finally
            {
                reader.Close();
            }
            Console.WriteLine(new string('-', 40));
            Console.WriteLine();

            // FileStream, GZipStream
        }
    }
}
