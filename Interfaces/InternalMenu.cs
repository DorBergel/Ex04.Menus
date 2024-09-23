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
        }

        public void AddItem(MenuItem i_Item)
        {
            m_PossibleItems.Add(m_NumberOfOptions++, i_Item);
        }

        public void Show()
        {
            Console.WriteLine($"** {Title} **");
            Console.WriteLine("--------------------");
            for (int i=0; i<m_PossibleItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {m_PossibleItems[i].Title}");
            }
            string returnOption = m_IsReturnable ? "Back" : "Exit";
            Console.WriteLine($"0. {returnOption}");

            int userChoice = GetValidInput(returnOption);
            
            if(userChoice == 0)
            {

            }
            else
            {

            }
        }

        public int GetValidInput(string i_ReturnOption)
        {
            string userInput = Console.ReadLine();
            int userChoice;

            while(true)
            {
                Console.WriteLine($"Please enter your choice (1 - {m_NumberOfOptions} or 0 to {i_ReturnOption})");
                if (int.TryParse(userInput, out userChoice) && userChoice >= 0 && userChoice <= m_NumberOfOptions)
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Invalid input, (1 - {m_NumberOfOptions} or 0 to {i_ReturnOption})");
                }
            }

            return userChoice;
        }
    }
}
