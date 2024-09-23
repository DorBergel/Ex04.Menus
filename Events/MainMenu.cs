using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class MainMenu
    {
        private List<InternalMenu> m_InternalMenus;

        public MainMenu()
        {
            m_InternalMenus = new List<InternalMenu>();
            m_InternalMenus.Add(null);
        }

        public void AddInternalMenu(InternalMenu i_InternalMenu)
        {
            m_InternalMenus.Add(i_InternalMenu);
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
                    Console.Clear();
                    m_InternalMenus[userChoice].Show();
                }
            } while (!isExitPressed);
        }

        private int DisplayMenuAndGetUserInput()
        {
            Console.WriteLine($"** Delegates Main Menu **");
            Console.WriteLine($"-------------------------");

            for (int i = 0; i < m_InternalMenus.Count; i++)
            {
                if (m_InternalMenus[i] != null)
                {
                    Console.WriteLine($"{i}. {m_InternalMenus[i].Title}");
                }
            }

            Console.WriteLine("0. Exit");
            int userChoice = GetValidInput(m_InternalMenus.Count);

            return userChoice;
        }

        private int GetValidInput(int i_MaxOption)
        {
            int userChoice;

            while (true)
            {
                Console.WriteLine($"Please enter your choice ({1}-{i_MaxOption} or 0 to Exit):");
                Console.Write(">> ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out userChoice) && userChoice >= 0 && userChoice <= i_MaxOption)
                {
                    break;
                }

                Console.WriteLine("Invalid input, please try again.");
            }

            return userChoice;
        }
    }
}
