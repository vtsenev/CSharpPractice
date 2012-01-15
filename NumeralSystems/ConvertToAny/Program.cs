using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConvertToAny
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 7: Write a program to convert from any numeral system of given
            // base s to any other numeral system of base d (2 ≤ s, d ≤  16).

            Console.Write("s = ");
            int s = int.Parse(Console.ReadLine());
            Console.Write("d = ");
            int d = int.Parse(Console.ReadLine());

            string numberInS = EnterNumberInS(s);

            string numberInD = ConvertToD(numberInS, s, d);

            Console.WriteLine(numberInD);
        }

        // handles the input of a number in the s-numeral base
        static string EnterNumberInS(int s)
        {
            Console.WriteLine("Enter a number in {0}-numeral system: ", s);
            string numberAsStr = Console.ReadLine();
            if (!CheckNumber(numberAsStr, s))
            {
                throw new ArgumentException("Number is not of the required numeral system.");
            }
            return numberAsStr;
        }

        // checks if the number is of the required numeral system (works with upper and lower case letters from 'a' to 'f')
        static bool CheckNumber(string numberAsStr, int s)
        {
            bool result = true;
            for (int i = 0; i < numberAsStr.Length; i++)
            {
                if (s <= 10)
                {
                    if (!(numberAsStr[i] >= 48 && numberAsStr[i] < s + 48))
                    {
                        return false;
                    }
                }
                else
                {
                    if (!((numberAsStr[i] >= 48 && numberAsStr[i] <= 57) || (numberAsStr[i] >= 65 && numberAsStr[i] < s + 55) || (numberAsStr[i] >= 97 && numberAsStr[i] < s + 87)))
                    {
                        return false;
                    }
                }   
            }
            return result;
        }

        // converts the number from the s-numeral base to the d-numeral base
        static string ConvertToD(string numberInS, int s, int d)
        {
            if (s == d)
            {
                return numberInS;
            }

            int decNum = 0;
            if (!(s == 10))
            {
                decNum = ConvertToDec(numberInS, s);
            }
            else
            {
                decNum = int.Parse(numberInS);
            }

            string result = ConvertDecToD(decNum, d); 

            return result;
        }

        // converts the s-based number to a decimal number
        static int ConvertToDec(string numberInS, int s)
        {
            char[] charArray = numberInS.ToCharArray();
            Array.Reverse(charArray);
            numberInS = new string(charArray);

            int decNum = 0;

            if (s < 10)
            {
                for (int i = 0; i < numberInS.Length; i++)
                {
                    decNum += (numberInS[i] - 48) * (int)Math.Pow(s, i);
                }
                return decNum;
            }

            for (int i = 0; i < numberInS.Length; i++)
            {
                if (numberInS[i] >= 48 && numberInS[i] <= 57)
                {
                    decNum += (numberInS[i] - 48) * (int)Math.Pow(s, i);
                }
                else if (numberInS[i] >= 65 && numberInS[i] < 55 + s)
                {
                    decNum += (numberInS[i] - 55) * (int)Math.Pow(s, i);
                }
                else if (numberInS[i] >= 97 && numberInS[i] < s + 87)
                {
                    decNum += (numberInS[i] - 87) * (int)Math.Pow(s, i);
                }
            }

            return decNum;
        }

        // converts a decimal number to a d-based number
        static string ConvertDecToD(int decNum, int d)
        {
            string dNum = "";
            while (decNum > 0)
            {
                int digit = decNum % d;
                if (digit < 10)
                {
                    dNum += digit.ToString();
                }
                else
                {
                    switch(digit)
                    {
                        case 10: dNum += "A"; break;
                        case 11: dNum += "B"; break;
                        case 12: dNum += "C"; break;
                        case 13: dNum += "D"; break;
                        case 14: dNum += "E"; break;
                        case 15: dNum += "F"; break;
                        default: throw new FormatException("Something went wrong.");
                    }
                }
                decNum /= d;
            }

            char[] charArray = dNum.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
