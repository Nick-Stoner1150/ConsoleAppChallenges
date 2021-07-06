using ChallengeOne_Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_UI
{
    public class ProgramUI
    {
        private MenuRepo _menuRepo = new MenuRepo();

        public void Run ()
        {

        }

        public void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                DisplayMenu();

                switch (Console.ReadLine())
                {
                    case "1":
                        CreateMenuItem();
                        break;
                    case "2":
                        ShowMenuItems();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!!");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number...");
                        break;
                }
            }
        }

        private void DeleteMenuItem()
        {
            throw new NotImplementedException();
        }

        private void ShowMenuItems()
        {
            throw new NotImplementedException();
        }

        private void CreateMenuItem()
        {
            throw new NotImplementedException();
        }

        public void DisplayMenu()
        {
            Console.WriteLine($"-----Welcome to Komodo Cafe!-----\n" +
                              $"\n" +
                              $"\n" +
                              $"1. Create New Menu Item\n" +
                              $"2. Current Menu List\n" +
                              $"3. Delete Menu Item\n" +
                              $"4. Exit Application");
        }


    }
}
