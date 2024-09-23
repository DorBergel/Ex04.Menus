using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class InternalMenu : MenuItem
    {
        private Dictionary<int, MenuItem> m_PossibleItems;
        private bool m_IsReturnable;
        private int m_NumberOfOptions;

        public InternalMenu(string i_ItemTitle, Action i_ItemAction) : base(i_ItemTitle, i_ItemAction)
        {
            m_NumberOfOptions = 1;
            m_PossibleItems = new Dictionary<int, MenuItem>();
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
                MenuItem selectedItem = m_PossibleItems[userInput];

                if (selectedItem is InternalMenu)
                {
                    Console.Clear();
                    ((InternalMenu)selectedItem).Show();
                }
                else
                {
                    selectedItem?.Run();
                    if (selectedItem == null)
                    {
                        Console.Clear();
                        isBackPressed = true;
                    }
                }
            } while (!isBackPressed);
        }

        public int PrintMenuAndGetUserInput()
        {
            Console.WriteLine($"** {Title} **");
            Console.WriteLine("--------------------");
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

            while (true)
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
