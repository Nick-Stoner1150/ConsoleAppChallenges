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

        private void SeeAllClaims()
        {
            Console.Clear();

            List<Claims> listOfClaims = _claimsRepo.ShowClaimsList();


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
    }
}
