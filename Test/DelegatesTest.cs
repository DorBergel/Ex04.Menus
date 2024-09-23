using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events;

namespace Test
{
    public class DelegatesTest
    {
        private MainMenu m_MainMenu;

        public DelegatesTest()
        {
            m_MainMenu = new MainMenu();
        }

        public void RunMainMenu()
        {
            InternalMenu versionAndCapitals = new InternalMenu("Version and Capitals", null);
            versionAndCapitals.AddItem(new MenuItem("Count Capitals", DelegatesMethods.CountCapitals));
            versionAndCapitals.AddItem(new MenuItem("Show Version", DelegatesMethods.ShowVersion));

            InternalMenu showCurrentTimeAndDate = new InternalMenu("Show Current Date/Time", null);
            showCurrentTimeAndDate.AddItem(new MenuItem("Show Current Date", DelegatesMethods.ShowDate));
            showCurrentTimeAndDate.AddItem(new MenuItem("Show Current Time", DelegatesMethods.ShowTime));

            m_MainMenu.AddInternalMenu(versionAndCapitals);
            m_MainMenu.AddInternalMenu(showCurrentTimeAndDate);

            m_MainMenu.Show();
        }
    }
}
