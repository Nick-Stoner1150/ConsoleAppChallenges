using ChallengeTwo_POCO;
using ChallengeTwo_Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChallengeTwo_Tests
{
    [TestClass]
    public class RepoTests
    {
        private Claims _claims;
        private ClaimsRepo _repo;

        [TestInitialize]

        public void Arrange ()
        {
            _repo = new ClaimsRepo();
            _claims = new Claims(1, Claims.ClaimType.Car, "The car was broken into", 1083.99m, new DateTime(2021, 1, 20), new DateTime(2020, 1, 29), true);
            
        }
        // Create Method
        [TestMethod]
        public void TestMethod1()
        {
            // Act 
            _repo.AddClaimToList(_claims);

            // Assert 
            Assert.IsNotNull(_claims);
        }
    }
}
