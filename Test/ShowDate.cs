using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class ShowDate : IAction
    {
        public void Run()
        {
            Console.WriteLine($"{DateTime.Now.ToShortDateString()} {Environment.NewLine}");
        }
    }
}
