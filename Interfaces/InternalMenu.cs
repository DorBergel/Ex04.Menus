using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class InternalMenu : MenuItem
    {
        Dictionary<int, MenuItem> m_PossibleItems;
        bool m_IsReturnable;
        int m_NumberOfOptions;

        public InternalMenu(string i_Title, bool i_IsReturnable) : base(i_Title)
        {
            m_PossibleItems = new Dictionary<int, MenuItem>();
            m_IsReturnable = i_IsReturnable;
            m_NumberOfOptions = 1;
            m_PossibleItems.Add(0, null);
        }

        public void AddItem(MenuItem i_Item)
        {
            m_PossibleItems.Add(m_NumberOfOptions++, i_Item);
        }

        public void Show()
        {
            bool isBackPressed = false;

            do
            {
                int userInput = PrintMenuAndGetUserInput();
                InternalMenu menu = m_PossibleItems[userInput] as InternalMenu;

                if (menu != null)
                {
                    Console.Clear();
                    menu.Show();
                }
                else if (m_PossibleItems[userInput] is IAction)
                {
                    ((IAction)m_PossibleItems[userInput]).Run();
                }
                else
                {
                    Console.Clear();
                    isBackPressed = true;
                }
            } while (!isBackPressed);
        }

        public int PrintMenuAndGetUserInput()
        {
            Console.WriteLine($"** {Title} **");
            Console.WriteLine("--------------------");
            /*for (int i = 0; i < m_PossibleItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {m_PossibleItems[i].Title}");
            }*/

            foreach (var item in m_PossibleItems)
            {
                if (item.Value != null)
                {
                    Console.WriteLine($"{item.Key}. {item.Value.Title}");
                }
            }

            Console.WriteLine($"0. Back");
            Console.WriteLine($"Please enter your choice (1 - {m_NumberOfOptions} or 0 to Back):");
            Console.Write(">> ");
            int userChoice = GetValidInput();

            return userChoice;
        }

        public int GetValidInput()
        {
            string userInput = Console.ReadLine();
            int userChoice;

            while(true)
            {
                if (int.TryParse(userInput, out userChoice) && userChoice >= 0 && userChoice <= m_NumberOfOptions)
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Invalid input, (1 - {m_NumberOfOptions} or 0 to Back):");
                }
            }

            return userChoice;
        }
    }
}
