using ChalleneOne.POCOs;
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
            SeedMenuItems();
            RunMenu();
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
            Console.Clear();

            Console.WriteLine("Enter the Menu Item Number that you would like to remove:");
            int itemToDelete = int.Parse(Console.ReadLine());

            bool wasDeleted = _menuRepo.RemoveMenuItemFromMenu(itemToDelete);
            
            if (wasDeleted)
            {
                Console.WriteLine($"Menu Item #{itemToDelete} was sucessfully deleted.");
            }
            else
            {
                Console.WriteLine("The Menu Item was not deleted.");
            }
        }

        private void ShowMenuItems()
        {
            Console.Clear();
            List<Menu> listOfMenuItems = _menuRepo.ShowMenu();

            WriteMenuItems(listOfMenuItems);

            
        }

        private void CreateMenuItem()
        {
            Console.Clear();

            Console.WriteLine("Enter the Menu Item Number (digit only: Ex: 3):");
            int mealNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Menu Item Name: ");
            string mealName = Console.ReadLine();

            Console.WriteLine("Enter Menu Item Description: ");
            string description = Console.ReadLine();

            Console.WriteLine("Enter Menu Item Ingredient (enter one at a time, pressing enter after each ingredient. " +
                "Press enter twice to complete list of ingredients): ");
            List<string> listOfIngredients = AddListOfIngredients();

            Console.WriteLine("Enter Price of Menu Item: ");
            decimal mealPrice = Decimal.Parse(Console.ReadLine());

            Menu newMenuItem = new Menu(mealNumber, mealName, description, listOfIngredients, mealPrice);
            _menuRepo.AddMenuItemToList(newMenuItem);
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

        public List<string> AddListOfIngredients ()
        {
            List<string> listOfIngredients = new List<string>();

            bool stillAdding = true;
            while (stillAdding)
            {
                string userInput = Console.ReadLine();
                if (userInput != "")
                {
                    listOfIngredients.Add(userInput);
                }
                else
                {
                    stillAdding = false;
                }
            }
            return listOfIngredients;
        }

        public void WriteMenuItems(List<Menu> listOfMenuItems)
        {
            foreach (Menu item in listOfMenuItems)
            {
                Console.WriteLine($"#{item.MealNumber}) {item.Name} -- {item.Description}\n" +
                                  $"\n" +
                                  $"Price: ${item.Price}\n" +
                                  $"\n" +
                                  $"Ingredients: ");
                foreach (var ingredient in item.Ingredients)
                {
                    Console.WriteLine($"{ingredient}");
                }
                Console.WriteLine("**********************************");
            }

        }
        public void SeedMenuItems()
        {
            Menu menuItem1 = new Menu(1, "Baconator", "Double stacked burger with the world's best bacon!", new List<string> { "cheese", "mayonaise", "beef", "ketchup" }, 5.99m);
            Menu menuItem2 = new Menu(2, "Jr. Baconator", "Just like the Baconator, just smaller!", new List<string> { "cheese", "mayonaise", "beef", "ketchup" }, 3.99m);
            Menu menuItem3 = new Menu(3, "Spicy Chicken Nuggets", "Our famous chicken nuggets with a little kick", new List<string> { "chicken", "nugget", "salt", "pepper" }, 2.99m);

            _menuRepo.AddMenuItemToList(menuItem1);
            _menuRepo.AddMenuItemToList(menuItem2);
            _menuRepo.AddMenuItemToList(menuItem3);
        }
    }
}
