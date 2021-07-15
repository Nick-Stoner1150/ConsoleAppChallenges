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
            _repo.AddClaimToList(_claims);
        }
        // Create Method
        [TestMethod]
        public void Create_MovieIsNull_ReturnFalse()
        {
            //Arrange
            Claims claim = null;
            
            // Act 
            bool result = _repo.AddClaimToList(claim);

            // Assert 
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Create_MoveIsNotNull_ReturnTrue()
        {
            // Arrange 

            // Act 
            bool result = _repo.AddClaimToList(_claims);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PeekNextClaim_ClaimIsPeeked_PeekedClaimNotNull()
        {
            //Arrange

            // Act
            Claims peekedClaim = _repo.PeekNextClaim();

            //
            Assert.AreEqual(peekedClaim, _claims);
        }

        [TestMethod]
        public void DequeClaim_ClaimIsDequed_ReturneNotNull()
        {
            // Arrange = already in list 

            // Act 
            Claims dequeuedClaim = _repo.DequeueClaim();

            // Assert
            Assert.AreEqual(dequeuedClaim, _claims);
        }
    }
}
