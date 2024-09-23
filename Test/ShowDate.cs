using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class ShowDate : MenuItem, IAction
    {
        public ShowDate(string i_ItemTitle) : base(i_ItemTitle) 
        { }

        public void Run()
        {
            Console.WriteLine($"{DateTime.Now.ToShortDateString()} {Environment.NewLine}");
        }
    }
}
