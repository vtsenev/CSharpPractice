using System;
using System.Net;

namespace Task4DownloadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 4: Write a program that downloads a file from Internet 
            // (e.g. http://www.devbg.org/img/Logo-BASD.jpg) and stores it
            // the current directory. Find in Google how to download files
            // in C#. Be sure to catch all exceptions and to free any used
            // resources in the finally block.

            WebClient webClient = new WebClient();
            try
            {
                webClient.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", "Logo-BASD.jpg");
                Console.WriteLine("Operation executed successfully.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("The address parameter is Nothing.");
            }
            catch (WebException)
            {
                Console.WriteLine("Invalid address or file does not exist.");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The method has been called simultaneously on multiple threads.");
            }
            finally
            {
                webClient.Dispose();
            }
        }
    }
}
