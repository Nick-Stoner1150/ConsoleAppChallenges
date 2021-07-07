using ChallengeTwo_POCO;
using ChallengeTwo_Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_UI
{
    public class ProgramUI
    {
        private ClaimsRepo _claimsRepo = new ClaimsRepo();

        public void Run()
        {
            SeedClaims();
            RunMenu();
        }

        private void RunMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                DisplayMenu();

                switch (Console.ReadLine())
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        CreateNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!!");
                        isRunning = false;
                        break;
                }
            }
        }

        private void CreateNewClaim()
        {
            throw new NotImplementedException();
        }

        private void TakeCareOfNextClaim()
        {
            throw new NotImplementedException();
        }
        private void DisplayMenu()
        {
                Console.WriteLine($"-------Komodo Claims Department-------\n" +
                                 $"\n" +
                                 $"\n" +
                                 $"Choose a menu item:\n" +
                                 $"1. See All Claims\n" +
                                 $"2. Take care of next claim\n" +
                                 $"3. Enter a new claim\n" +
                                 $"4. Exit Application");
        }

        public void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claims> claimsInQueue = _claimsRepo.ShowClaimsList();

            WriteClaimsInQueue(claimsInQueue);

        }

        public void WriteClaimsInQueue(Queue<Claims> claimsQueue)
        {
            foreach (Claims claim in claimsQueue)
            {
                Console.WriteLine($"ClaimID          Type         Description                 Amount              DateOfAccident         DateOfClaim           IsValid\n" +
                                  $"{claim.ClaimID}  {claim.Type} {claim.Descripion}          {claim.ClaimAmount} {claim.DateOfIncident} {claim.DateOfClaim}   {claim.IsValid}\n" +
                                  $"--------------------------------------------------------------------------------------------------------------------------------------------");
            }
        }

        public void SeedClaims()
        {
            Claims claim1 = new Claims(1, Claims.ClaimType.Car, "The car was broken into", 1083.99m, new DateTime(2021, 1, 20), new DateTime(2020, 1, 29), true);

            _claimsRepo.AddClaimToList(claim1);
        }

    }
}
