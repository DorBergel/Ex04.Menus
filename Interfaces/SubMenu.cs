using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class SubMenu : MenuItem
    {
        private readonly eBackOrExit r_TerminationType;
        private readonly List<MenuItem> r_ItemsList;

        public SubMenu(string i_MenuTitle) : base(i_MenuTitle)
        {
            r_TerminationType = eBackOrExit.Back;
        }

        public SubMenu(string i_MenuTitle, eBackOrExit i_TerminationChoice) : base(i_MenuTitle)
        {
            r_TerminationType = i_TerminationChoice;
        }

        public eBackOrExit TerminationType
        {
            get
            {
                return r_TerminationType;
            }
        }

        public Dictionary<int, MenuItem> Items
        {
            get
            {
                return r_ItemsList;
            }
        }


    }
}
