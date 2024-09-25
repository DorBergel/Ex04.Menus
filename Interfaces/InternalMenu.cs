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
            m_PossibleItems.Add(0, new ActionItem("Back", null));
        }

        public void AddItem(MenuItem i_Item)
        {
            m_PossibleItems.Add(m_NumberOfOptions++, i_Item);
        }

        public override void Show()
        {
            bool isBackPressed = false;
            Console.Clear();

            do
            {
                int userInput = PrintMenuAndGetUserInput();
                if (userInput == 0)
                {
                    Console.Clear();
                    isBackPressed = true;
                }
                else
                {
                    MenuItem selectedItem = m_PossibleItems[userInput];
                    selectedItem.Show();
                }
            } while (!isBackPressed);
        }

        public int PrintMenuAndGetUserInput()
        {
            string menuTitle = $"** {Title} **";
            Console.WriteLine(menuTitle);
            Console.WriteLine(new string('-', menuTitle.Length));
            foreach (var item in m_PossibleItems)
            {
                if (item.Value.Title != "Back")
                {
                    Console.WriteLine($"{item.Key}. {item.Value.Title}");
                }
            }

            Console.WriteLine($"0. {m_PossibleItems[0].Title}");
            int userChoice = GetValidInput(m_NumberOfOptions);

            return userChoice;
        }

        public int GetValidInput(int i_MaxOption)
        {
            int userChoice = -1;
            bool isValidInput = false;

            do
            {
                Console.WriteLine($"Please enter your choice (1-{i_MaxOption - 1} or 0 to Exit):");
                Console.Write(">> ");
                string userInput = Console.ReadLine();

                try
                {
                    isValidInput = checkIfInputValid(userInput, i_MaxOption);
                    userChoice = int.Parse(userInput);
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
            } while (!isValidInput);

            return userChoice;
        }

        private bool checkIfInputValid(string i_UserInput, int i_MaxOption)
        {
            int userChoiceNumber;
            bool isValidInput = int.TryParse(i_UserInput, out userChoiceNumber);

            if (!isValidInput)
            {
                throw new FormatException("Error: Only digits allowed here. Try again.");
            }
            else if (userChoiceNumber < 0 || userChoiceNumber >= i_MaxOption)
            {
                throw new ArgumentException("Error: Your input is out of range. Try again.");
            }

            return isValidInput;
        }
    }
}
