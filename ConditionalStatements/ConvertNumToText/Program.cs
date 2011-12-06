using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class Program
    {
        static int hundreds = 0;
        static int tens;
        static int ones;

        static void Main(string[] args)
        {
            // * Write a program that converts a number in the range [0...999]
            //   to a text corresponding to its English pronunciation. Examples:
	        //    0 -> "Zero"
	        //  273 -> "Two hundred seventy three"
	        //  400 -> "Four hundred"
	        //  501 -> "Five hundred and one"
	        //  711 -> "Severn hundred and eleven"

            Console.Write("Enter a number (0-999): ");
            string input = Console.ReadLine();
            int number = int.Parse(input);
            int temp;
            if (number > 99)
            {
                hundreds = number / 100;
                temp = number - (hundreds * 100);
                tens = temp / 10;
                ones = temp - (tens * 10);
            }
            else
            {
                tens = number / 10;
                ones = number - (tens * 10);
            }

            string result = "";


            if (number < 100)
            {
                result = Deal(number);
                Print(result);
                return;
            }

            temp = number - (hundreds * 100);
            if (temp == 0)
            {
                result = PrintDigits(hundreds) + " hundred";
                Print(result);
                return;
            }

            if (temp < 21)
            {
                result = PrintDigits(hundreds) + " hundred" + " and " + Deal(temp);
            }
            else
            {
                result = PrintDigits(hundreds) + " hundred " + Deal(temp);
            }
            Print(result);
        }

        static void Print(string numStr)
        {
            string firstLetter = numStr[0].ToString().ToUpper();
            string rest = numStr.Substring(1);
            string result = firstLetter + rest;
            Console.WriteLine(result);
        }

        static string PrintDigits(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: return "error";
            }
        }

        static string PrintTens(int tens)
        {
            string tenth = "";
            switch (tens)
            {
                case 2: tenth = "twenty"; break;
                case 3: tenth = "thirty"; break;
                case 4: tenth = "forty"; break;
                case 5: tenth = "fifty"; break;
                case 6: tenth = "sixty"; break;
                case 7: tenth = "seventy"; break;
                case 8: tenth = "eighty"; break;
                case 9: tenth = "ninety"; break;
                default: Console.WriteLine("error"); break;
            }
            return tenth;
        }

        static string PrintTensAndDigits()
        {
            string tempStr = PrintTens(tens);
            if (ones == 0)
            {
                return tempStr;
            }
            else
            {
                return tempStr + " " + PrintDigits(ones);
            }
        }

        static string PrintTeens(int teen)
        {
            switch (teen)
            {
                case 10: return "ten";
                case 11: return "eleven";
                case 12: return "twelve";
                case 13: return "thirteen";
                case 14: return "fourteen";
                case 15: return "fifteen";
                case 16: return "sixteen";
                case 17: return "seventeen";
                case 18: return "eighteen";
                case 19: return "nineteen";
                default: return "error";
            }
        }

        static string Deal(int number)
        {
            if (number < 10)
            {
                return PrintDigits(number);
            }
            else if (number > 19)
            {
                return PrintTensAndDigits();
            }
            else
            {
                return PrintTeens(number);
            }
        }
    }
}