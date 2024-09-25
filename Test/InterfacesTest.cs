using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class InterfacesTest
    {
        private MainMenu m_MainMenu;

        public InterfacesTest()
        {
            m_MainMenu = new MainMenu();
        }

        public void RunMainMenu()
        {
            InternalMenu versionAndCapitals = new InternalMenu("Version and Capitals", false);
            versionAndCapitals.AddItem(new ActionItem("Count Capitals", new CountCapitals()));
            versionAndCapitals.AddItem(new ActionItem("Show Version", new ShowVersion()));
            
            InternalMenu showCurrentTimeAndDate = new InternalMenu("Show Current Date/Time", false);
            showCurrentTimeAndDate.AddItem(new ActionItem("Show Current Date", new ShowDate()));
            showCurrentTimeAndDate.AddItem(new ActionItem("Show Current Time", new ShowTime()));

            m_MainMenu.AddInternalMenu(versionAndCapitals);
            m_MainMenu.AddInternalMenu(showCurrentTimeAndDate);

            m_MainMenu.Show();
        }
    }
}
