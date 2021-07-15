using ChallengeThree_Pocos;
using ChallengeThree_Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ChallengeThree_UnitTests
{
    [TestClass]
    public class BadgeRepoUnitTests
    {
        [TestMethod]
        public void Create_BadgeIsNull_ReturnFalse()
        {
            // Arrange
            Badge badge = null;
            BadgeRepo repo = new BadgeRepo();

            // Act 
            bool result = repo.AddBadgeToDictionary(badge);

            // Assert 
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void Create_BadgeIsNotNull_ReturnTrue()
        {
            // Arrange
            Badge badge = new Badge(55, new List<string> {"Door1", "Door2" });
            BadgeRepo repo = new BadgeRepo();

            // Act
            bool result = repo.AddBadgeToDictionary(badge);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetByBadgeID_BadgeExists_ReturnBadge()
        {
            // Arrange
            Badge badge = new Badge(55, new List<string> { "Door1", "Door2" });
            BadgeRepo repo = new BadgeRepo();
            repo.AddBadgeToDictionary(badge);
            // int id = 55;

            // Act
            Badge result = repo.GetBadgeByBadgeID(badge.BadgeID);

            // Assert
            Assert.AreEqual(badge.BadgeID, result.BadgeID);

        }

    }
}
