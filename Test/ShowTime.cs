using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class ShowTime : IAction
    {
        public void Run()
        {
            Console.WriteLine($"{DateTime.Now.ToShortTimeString()} {Environment.NewLine}");
        }
    }
}
