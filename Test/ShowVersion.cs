using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class ShowVersion : MenuItem, IAction
    {
        public ShowVersion(string i_ItemTitle) : base(i_ItemTitle)
        { }

        public void Run()
        {
            Console.WriteLine($"App version: 24.3.4.0495 {Environment.NewLine}");
        }
    }
}
