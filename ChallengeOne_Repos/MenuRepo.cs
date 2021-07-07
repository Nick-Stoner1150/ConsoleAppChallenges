using ChalleneOne.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Repos
{
    public class MenuRepo
    {
        List<Menu> _menuItems = new List<Menu>();
        
        //Create 
        public void AddMenuItemToList(Menu menuItem)
        {
            _menuItems.Add(menuItem);
        }

        // Read
        public List<Menu> ShowMenu()
        {
            foreach (var content in _menuItems)
            {
                return _menuItems;
            }
            return null;
        }

        // Update




        // Delete 
        public bool RemoveMenuItemFromMenu (int menuNumber)
        {
            Menu menuItem = GetMenuItemByNumber(menuNumber);

            if (menuItem == null)
            {
                return false;
            }

            int initialCount = _menuItems.Count;
            _menuItems.Remove(menuItem);

            if (initialCount > _menuItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // Helper Methods
        public Menu GetMenuItemByNumber (int mealNumber)
        {
            foreach (var content in _menuItems)
            {
                if (content.MealNumber == mealNumber)
                {
                    return content;
                }
            }

            return null;
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
    }
}
