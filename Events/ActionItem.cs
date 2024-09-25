using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class ActionItem : MenuItem
    {
        public event Action<MenuItem> ItemSelected;

        public ActionItem(string i_ItemTitle) : base(i_ItemTitle)
        { }

        public override void Show()
        {
            OnItemSelected();
        }

        protected virtual void OnItemSelected()
        {
            if (ItemSelected != null)
            {
                ItemSelected.Invoke(this);
            }
        }
    }
}
