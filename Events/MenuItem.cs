using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class MenuItem
    {
        private string m_Title;
        private Action m_Action;

        public MenuItem(string i_Title, Action i_Action = null)
        {
            m_Title = i_Title;
            m_Action = i_Action;
        }

        public string Title
        {
            get
            {
                return m_Title;
            }
        }

        public void Run()
        {
            m_Action?.Invoke();
        }
    }
}
