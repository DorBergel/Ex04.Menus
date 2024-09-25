using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class ShowVersion : IAction
    {
        public void Run()
        {
            Console.WriteLine($"App Version: 24.3.4.0495 {Environment.NewLine}");
        }
    }
}
