using ChallengeTwo_POCO;
using ChallengeTwo_Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChallengeTwo_POCO.Claims;

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
            Console.Clear();
            Claims newClaim = new Claims();

            Console.WriteLine("Create New Claim:\n");
            Console.WriteLine("Enter the claim ID: "); 
            newClaim.ClaimID = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter the claim type number: \n" +
                              "1. Car\n" +
                              "2  Home\n" +
                              "3. Theft\n");
            int typeAsInt = int.Parse(Console.ReadLine());
            newClaim.Type = (ClaimType)typeAsInt;

            Console.WriteLine("Description: ");
            newClaim.Descripion = Console.ReadLine();

            Console.WriteLine("Amount of Damage: ");
            newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Date Of Accident: (MM-DD-YYYY)");
            newClaim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Date Of Claim: (MM-DD-YYYY)");
            newClaim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Is the claim valid? (y/n)");
            string isValidString = Console.ReadLine().ToLower();
            if (isValidString == "y")
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }

            _claimsRepo.AddClaimToList(newClaim);
        }

        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            Console.WriteLine("Next Claim In Queue:");

            WritePeekedCalim(_claimsRepo.PeekNextClaim());

            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                Claims dequeuedClaim =_claimsRepo.DequeueClaim();
                Console.WriteLine("You Successfuly Completed Claim:");
                WritePeekedCalim(dequeuedClaim);
            }
            else
            {
                Console.WriteLine("Claim not dealt with, press any key to return to the main menu!");
            }
              
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

                Console.WriteLine($"{claim.ClaimID,5}  {claim.Descripion,25} ${claim.ClaimAmount,20} {claim.DateOfIncident,30} {claim.DateOfClaim,30} {claim.IsValid,15}");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------");
            }
        }

        public void SeedClaims()
        {
            Claims claim1 = new Claims(1, Claims.ClaimType.Car, "The car was broken into", 1083.99m, new DateTime(2021, 1, 20), new DateTime(2020, 1, 29), true);
            Claims claim2 = new Claims(2, Claims.ClaimType.Car, "The car was broken into", 1083.99m, new DateTime(2021, 1, 20), new DateTime(2020, 1, 29), true);

            _claimsRepo.AddClaimToList(claim1);
            _claimsRepo.AddClaimToList(claim2);
        }

        public void WritePeekedCalim(Claims claim)
        {
            Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                              $"Type: {claim.Type}\n" +
                              $"Description: {claim.Descripion}\n" +
                              $"Amount: ${claim.ClaimAmount}\n" +
                              $"Date Of Accident: {claim.DateOfIncident}\n" +
                              $"Date Of Claim: {claim.DateOfClaim}\n" +
                              $"Is Valid: {claim.IsValid}\n");
        }
    }
}
