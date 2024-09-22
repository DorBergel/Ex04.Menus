using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class MenuItem
    {
        string m_Title;
        List<MenuItem> m_SubMenus;
        Action m_Action;

        public string Title
        {
            get
            {
                return m_Title;
            }
        }

        public List<MenuItem> SubMenus
        {
            get
            {
                return m_SubMenus;
            }
        }

        public Action Action
        {
            get
            {
                return Action;
            }
        }

        public MenuItem(string i_Title, Action i_Action=null)
        {
            m_Title = i_Title;
            m_SubMenus = new List<MenuItem>();
            m_Action = i_Action;
        }

        public void AddMenu(MenuItem i_MenuItem)
        {
            m_SubMenus.Add(i_MenuItem);
        }

        public bool MenuHasSubItem()
        {
            return m_SubMenus.Count > 0;
        }
    }
}
