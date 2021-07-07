using ChalleneOne.POCOs;
using ChallengeOne_Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeOneUnitTests
{
    [TestClass]
    public class MenuUnitTests
    {
        private Menu _menu;
        private MenuRepo _repo; 

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepo();
            _menu = new Menu(1, "Baconator", "A Double Stacked Burger With Bacon and our famous special sauce", new List<string> { "meat", "cheese", "special sauce" }, 5.99m);
            _repo.AddMenuItemToList(_menu);
        }

        // Add Method
        [TestMethod]

        public void AddToList_ShouldGetNotNull()
        {
            // Arrange 
            Menu menuItem = new Menu();
            menuItem.Name = "Double Butter Burger";
            menuItem.MealNumber = 2;

            MenuRepo repo = new MenuRepo();

            //Act 
            repo.AddMenuItemToList(menuItem);
            Menu menuItemFromDirectory = repo.GetMenuItemByNumber(2);

            //Assert 
            Assert.IsNotNull(menuItemFromDirectory);
        }

        // Read Method
        [TestMethod]

        public void ReadContentList_ShouldGetNotNull()
        {
            // Arrange 
            Menu menuItem = new Menu(3, "Single Butter Burger", "The best single patty burger on the market", new List<string> { "cheese", "tomato", "meat" }, 5.99m );
            Menu menuItem2 = new Menu(4, "Burger", "The best single patty burger on the market", new List<string> { "cheese", "tomato", "meat" }, 4.99m);
            Menu menuItem3 = new Menu(5, "Butter Burger", "The best single patty burger on the market", new List<string> { "cheese", "tomato", "meat" }, 9.99m);

            MenuRepo repo = new MenuRepo();

            //Act 
            repo.AddMenuItemToList(menuItem);
            repo.AddMenuItemToList(menuItem2);
            repo.AddMenuItemToList(menuItem3);

            List<Menu> listOfMenuItems = repo.ShowMenu();

            //Assert 
            Assert.AreEqual(3, listOfMenuItems.Count);
        }

        // Delete Method
        [TestMethod]

        public void DeleteMenuItem_ShouldReturnTrue()
        {
            // Arrange (above) 

            // Act 
            bool deleteResult = _repo.RemoveMenuItemFromMenu(_menu.MealNumber);

            //Assert 
            Assert.IsTrue(deleteResult);
        }
    }
}
