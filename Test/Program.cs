﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Program
    {
        public static void Main()
        {
            InterfacesTest interfaceMenu = new InterfacesTest();
            interfaceMenu.RunMainMenu();

            DelegatesTest delegatesMenu = new DelegatesTest();
            delegatesMenu.RunMainMenu();
        }
    }
}
