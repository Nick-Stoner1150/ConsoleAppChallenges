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
            Console.WriteLine($" {"Claim ID",-15} {"Description",-25} {"Claim Amount",-10} {"Date Of Accident",25} {"Date Of Claim",25} {"Is Valid",25}\n");
            foreach (Claims claim in claimsQueue)
            {

                Console.WriteLine($"{claim.ClaimID,5}  {claim.Descripion,25} {claim.ClaimAmount,20} {claim.DateOfIncident,30} {claim.DateOfClaim,30} {claim.IsValid,15}");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            }
        }

        public void SeedClaims()
        {
            Claims claim1 = new Claims(1, Claims.ClaimType.Car, "The car was broken into", 1083.99m, new DateTime(2021, 1, 20), new DateTime(2020, 1, 29), true);

            _claimsRepo.AddClaimToList(claim1);
        }

    }
}
