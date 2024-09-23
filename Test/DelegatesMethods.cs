using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class DelegatesMethods
    {
        public static void CountCapitals()
        {
            int countCapitalLetters = 0;

            Console.WriteLine("Please write a sentence.");
            Console.Write(">> ");
            string userInput = Console.ReadLine();

            foreach (char c in userInput)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    countCapitalLetters++;
                }
            }

            Console.WriteLine($"There are {countCapitalLetters} capital letters in your sentence.{Environment.NewLine}");
        }

        public static void ShowVersion()
        {
            Console.WriteLine($"App version: 24.3.4.0495 {Environment.NewLine}");
        }

        public static void ShowTime()
        {
            Console.WriteLine($"{DateTime.Now.ToShortTimeString()} {Environment.NewLine}");
        }

        public static void ShowDate()
        {
            Console.WriteLine($"{DateTime.Now.ToShortDateString()} {Environment.NewLine}");
        }
    }
}
