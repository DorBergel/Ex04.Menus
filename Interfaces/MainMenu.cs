using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class MainMenu
    {
        private List<MenuItem> m_MainMenuItems;


        public MainMenu()
        {
            m_MainMenuItems = new List<MenuItem>();
            m_MainMenuItems.Add(new ActionItem("Exit", null));
        }

        public void AddInternalMenu(InternalMenu i_InternalMenu)
        {
            m_MainMenuItems.Add(i_InternalMenu);
        }

        public void Show()
        {
            bool isExitPressed = false;

            do
            {
                int userChoice = DisplayMenuAndGetUserInput();
                isExitPressed = userChoice == 0;
                if (!isExitPressed)
                {
                    m_MainMenuItems[userChoice].Show();
                }
                else
                {
                    Console.Clear();
                }
            } while (!isExitPressed);
        }

        private int DisplayMenuAndGetUserInput()
        {
            Console.WriteLine($"** Interfaces Main Menu **");
            Console.WriteLine($"--------------------------");

            for (int i = 1; i < m_MainMenuItems.Count; i++)
            {
                Console.WriteLine($"{i}. {m_MainMenuItems[i].Title}");
            }

            Console.WriteLine($"0. {m_MainMenuItems[0].Title}");
            int userChoice = GetValidInput(m_MainMenuItems.Count);

            return userChoice;
        }

        private int GetValidInput(int i_MaxOption)
        {
            int userChoice;

            while(true)
            {
                Console.WriteLine($"Please enter your choice ({1}-{i_MaxOption - 1} or 0 to Exit):");
                Console.Write(">> ");
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
