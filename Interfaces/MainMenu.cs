using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class MainMenu
    {
        MenuItem m_MainMenu;


        public MainMenu(MenuItem i_MenuItem)
        {
            m_MainMenu = i_MenuItem;
        }

        public void Show()
        {
            int choice;

            while (true)
            {
                DisplayMenu(m_MainMenu);

                choice = GetValidInput(m_MainMenu.SubMenus.Count);
                var selectedItem = m_MainMenu.SubMenus[choice - 1];

                if (selectedItem.MenuHasSubItem())
                {
                    m_MainMenu = selectedItem;
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    selectedItem.Action?.Invoke();
                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private void DisplayMenu(MenuItem i_MenuItem)
        {
            Console.WriteLine($"** {i_MenuItem.Title} **");
            Console.WriteLine($"--------------------");

            for (int i = 0; i < i_MenuItem.SubMenus.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {i_MenuItem.SubMenus[i].Title}");
            }
        }

        private int GetValidInput(int i_MaxOption)
        {
            int userChoice;

            while(true)
            {
                Console.Write($"Please enter your choice ({1}-{i_MaxOption - 1} or 0 to {'*'}"); // TODO think of the condition to when it should display 'back' or 'exit'
                string userInput = Console.ReadLine();
                
                if(int.TryParse(userInput, out userChoice) && userChoice >= 0 && userChoice <= i_MaxOption)
                {
                    break;
                }

                Console.WriteLine("Invalid input, please try again.");
            }

            return userChoice;
        }
    }
}
