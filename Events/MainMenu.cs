using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class MainMenu
    {
        private List<MenuItem> m_MainMenuItems;

        public MainMenu()
        {
            m_MainMenuItems = new List<MenuItem>();
            m_MainMenuItems.Add(new ActionItem("Exit"));
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
            } while (!isExitPressed);
        }

        public int DisplayMenuAndGetUserInput()
        {
            Console.WriteLine($"** Delegates Main Menu **");
            Console.WriteLine($"-------------------------");

            for (int i = 1; i < m_MainMenuItems.Count; i++)
            {
                Console.WriteLine($"{i}. {m_MainMenuItems[i].Title}");
            }

            Console.WriteLine($"0. {m_MainMenuItems[0].Title}");
            int userChoice = GetValidInput(m_MainMenuItems.Count);

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
