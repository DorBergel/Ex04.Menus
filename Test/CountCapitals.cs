using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class CountCapitals : IAction
    {
        public void Run()
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
    }
}
