using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public abstract class MenuItem
    {
        string m_Title;

        public MenuItem(string i_Title)
        {
            this.m_Title = i_Title;
        }

        public string Title
        {
            get { return m_Title; }
        }

    }
}
