using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task10
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a program that prints all possible cards from a standard deck 
            // of 52 cards (without jokers). The cards should be printed with their
            // English names. Use nested for loops and switch-case.

            string name = "";
            for (int cardType = 2; cardType < 15; cardType++)
            {
                switch (cardType)
                {
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10: name = cardType + " of "; break;
                    case 11: name = "Jack of "; break;
                    case 12: name = "Queen of "; break;
                    case 13: name = "King of "; break;
                    case 14: name = "Ace of "; break;
                    default: Console.WriteLine("Wrong card type. Should be 2-14."); break;
                }
                for (int cardColor = 1; cardColor < 5; cardColor++)
                {
                    switch (cardColor)
                    {
                        case 1: Console.WriteLine(name + "Spades"); break;
                        case 2: Console.WriteLine(name + "Diamonds"); break;
                        case 3: Console.WriteLine(name + "Hearts"); break;
                        case 4: Console.WriteLine(name + "Clubs"); break;
                        default: Console.WriteLine("Wrong card color. Should be 1-4."); break;
                    }
                }
            }
        }
    }
}
