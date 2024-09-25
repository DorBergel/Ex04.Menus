using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class ActionItem : MenuItem
    {
        private IAction m_Action;

        public ActionItem(string i_ActionTitle, IAction i_Action) : base(i_ActionTitle)
        {
            m_Action = i_Action;
        }

        public override void Show()
        {
            m_Action.Run();
        }
    }
}
