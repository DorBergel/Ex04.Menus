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
            InternalMenu versionAndCapitals = new InternalMenu("Version and Capitals");
            ActionItem countCapitals = new ActionItem("Count Capitals");
            ActionItem showVersion = new ActionItem("Show Version");
            versionAndCapitals.AddItem(countCapitals);
            versionAndCapitals.AddItem(showVersion);

            InternalMenu showCurrentTimeAndDate = new InternalMenu("Show Current Date/Time");
            ActionItem showDate = new ActionItem("Show Current Date");
            ActionItem showTime = new ActionItem("Show Current Time");
            showCurrentTimeAndDate.AddItem(showDate);
            showCurrentTimeAndDate.AddItem(showTime);

            m_MainMenu.AddInternalMenu(versionAndCapitals);
            m_MainMenu.AddInternalMenu(showCurrentTimeAndDate);

            countCapitals.ItemSelected += CountCapitals_ItemSelected;
            showVersion.ItemSelected += ShowVersion_ItemSelected;
            showDate.ItemSelected += ShowDate_ItemSelected;
            showTime.ItemSelected += ShowTime_ItemSelected;

            m_MainMenu.Show();
        }

        private void CountCapitals_ItemSelected(MenuItem i_Invoker)
        {
            DelegatesMethods.CountCapitals();
        }

        private void ShowVersion_ItemSelected(MenuItem i_Invoker)
        {
            DelegatesMethods.ShowVersion();
        }

        private void ShowDate_ItemSelected(MenuItem i_Invoker)
        {
            DelegatesMethods.ShowDate();
        }

        private void ShowTime_ItemSelected(MenuItem i_Invoker)
        {
            DelegatesMethods.ShowTime();
        }
    }
}
