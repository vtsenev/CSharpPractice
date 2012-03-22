using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Task2_ShoppingCenter
{
    class Program
    {
        static int commandsNumber;
        static string[] commands;
        static Inventory shop = new Inventory();
        static StringBuilder output = new StringBuilder();
        const string INPUT_PATH = @"../../in.txt";

        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture =
                System.Globalization.CultureInfo.InvariantCulture;
            InputFromConsole();
            //InputFromFile();
            ParseAndExecuteCommands();
            PrintOutput();
        }

        static void InputFromConsole()
        {
            commandsNumber = int.Parse(Console.ReadLine());
            commands = new string[commandsNumber];
            for (int i = 0; i < commandsNumber; i++)
            {
                commands[i] = Console.ReadLine();
            }
        }

        static void InputFromFile()
        {
            using (StreamReader sr = new StreamReader(INPUT_PATH))
            {
                commandsNumber = int.Parse(sr.ReadLine());
                commands = new string[commandsNumber];
                for (int i = 0; i < commandsNumber; i++)
                {
                    commands[i] = sr.ReadLine();
                }
            }
        }

        static void ParseAndExecuteCommands()
        {
            for (int i = 0; i < commandsNumber; i++)
            {
                string command = commands[i];
                StringBuilder commandType = new StringBuilder();
                int charIndex = 0;
                while (char.IsLetter(command[charIndex]))
                {
                    commandType.Append(command[charIndex]);
                    charIndex++;
                }
                switch (commandType.ToString())
                {
                    case "AddProduct": AddProductCommand(command); break;
                    case "DeleteProducts": DeleteProductsCommand(command); break;
                    case "FindProductsByName": FindProductsByNameCommand(command); break;
                    case "FindProductsByPriceRange": FindProductsByPriceRangeCommand(command); break;
                    case "FindProductsByProducer": FindProductsByProducerCommand(command); break;
                    default: throw new ArgumentException("command not recognized");
                }
            }
        }

        static void AddProductCommand(string command)
        {
            command = command.Replace("AddProduct ", "");
            string[] commandSegments = command.Split(';');
            string name = commandSegments[0];
            decimal price = decimal.Parse(commandSegments[1]);
            string producer = commandSegments[2];
            output.AppendLine(shop.AddProduct(name, price, producer));
        }

        static void DeleteProductsCommand(string command)
        {
            command = command.Replace("DeleteProducts ", "");
            if (command.Contains(';'))
            {
                string[] commandSegments = command.Split(';');
                string name = commandSegments[0];
                string producer = commandSegments[1];
                output.AppendLine(shop.DeleteProducts(name, producer));
            }
            else
            {
                output.AppendLine(shop.DeleteProducts(command));
            }
        }

        static void FindProductsByNameCommand(string command)
        {
            command = command.Replace("FindProductsByName ", "");
            output.AppendLine(shop.FindProductsByName(command));
        }

        static void FindProductsByPriceRangeCommand(string command)
        {
            command = command.Replace("FindProductsByPriceRange ", "");
            string[] commandSegments = command.Split(';');
            decimal fromPrice = decimal.Parse(commandSegments[0]);
            decimal toPrice = decimal.Parse(commandSegments[1]);
            output.AppendLine(shop.FindProductsByPriceRange(fromPrice, toPrice));
        }

        static void FindProductsByProducerCommand(string command)
        {
            command = command.Replace("FindProductsByProducer ", "");
            output.AppendLine(shop.FindProductsByProducer(command));
        }

        static void PrintOutput()
        {
            Console.WriteLine(output.ToString());
        }
    }

    class Product
    {
        public string Name { get; private set; }
        public string Producer { get; private set; }
        public decimal Price { get; private set; }

        public Product(string name, string producer, decimal price)
        {
            this.Name = name;
            this.Producer = producer;
            this.Price = price;
        }

        public override string ToString()
        {
            string product = string.Format("{0};{1};{2:0.00}", this.Name, this.Producer, this.Price);
            return "{" + product + "}";
        }
    }

    class Inventory
    {
        private List<Product> products;

        public Inventory()
        {
            products = new List<Product>();
        }

        public string AddProduct(string name, decimal price, string producer)
        {
            products.Add(new Product(name, producer, price));
            return "Product added";
        }

        public string DeleteProducts(string name, string producer)
        {
            int count = products.Count;
            products.RemoveAll(product => product.Name == name && product.Producer == producer);
            int removedCount = count - products.Count;
            return FormatResult(removedCount);
        }

        public string DeleteProducts(string producer)
        {
            int count = products.Count;
            products.RemoveAll(product => product.Producer == producer);
            int removedCount = count - products.Count;
            return FormatResult(removedCount);
        }

        public string FindProductsByName(string name)
        {
            var resultProducts = products.FindAll(product => product.Name == name).ToList();
            return FormatResult(resultProducts);
        }

        public string FindProductsByPriceRange(decimal fromPrice, decimal toPrice)
        {
            var resultProducts = products.FindAll(product => product.Price >= fromPrice && product.Price <= toPrice).ToList();
            return FormatResult(resultProducts);
        }

        public string FindProductsByProducer(string producer)
        {
            var resultProducts = products.FindAll(product => product.Producer == producer).ToList();
            return FormatResult(resultProducts);
        }

        private string FormatResult(List<Product> resultProducts)
        {
            if (resultProducts.Count == 0)
            {
                return "No products found";
            }
            List<string> result = new List<string>();
            foreach (Product product in resultProducts)
            {
                result.Add(product.ToString());
            }
            result.Sort();
            StringBuilder sb = new StringBuilder();
            foreach (string line in result)
            {
                sb.AppendLine(line);
            }
            string resultString = sb.ToString();
            resultString = resultString.Substring(0, resultString.Length - 2);
            return resultString;
        }

        private string FormatResult(int removedCount)
        {
            if (removedCount == 0)
            {
                return "No products found";
            }
            else
            {
                string output = removedCount + " products deleted";
                return output;
            }
        }
    }
}
