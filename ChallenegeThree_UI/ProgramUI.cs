using ChallengeThree_Pocos;
using ChallengeThree_Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallenegeThree_UI
{
    public class ProgramUI
    {
        BadgeRepo _badgeRepo = new BadgeRepo();
        public void Run()
        {
            SeedBadges();
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
                        AddABadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                }

            }
        }

        private void ListAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> badgeDictionary = _badgeRepo.ShowListOfBadges();

            WriteBadgeToConsole(badgeDictionary);

        }

        public void EditBadge()
        {
            Console.WriteLine("What is the Badge Number to Update?");
            int badgeID = int.Parse(Console.ReadLine());

            Badge badgeToUpdate  = _badgeRepo.GetBadgeByBadgeID(badgeID);

            if (badgeToUpdate != null)
            {
                Console.WriteLine($"{badgeToUpdate.BadgeID} has access to doors: \n");

                WriteContentInListOfStrings(badgeToUpdate.DoorNames);
            }

            Console.WriteLine("What would you like to do?\n" +
                              "\n" +
                              "1. Remove a door\n" +
                              "2. Add a door");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Which door would you like to remove?");
                    string doorToRemove = Console.ReadLine();
                    if (badgeToUpdate.DoorNames.Contains(doorToRemove))
                    {
                        badgeToUpdate.DoorNames.Remove(doorToRemove);
                        Console.WriteLine("Door Removed");
                    }
                    else
                    {
                        Console.WriteLine($"{badgeID} does not containt that door.");
                    }
                    Console.WriteLine($"{badgeID} has access to\n");
                    WriteContentInListOfStrings(badgeToUpdate.DoorNames);
                    break;
                case "2":
                    Console.WriteLine("List a door you want to add: ");
                    string doorToAdd = Console.ReadLine();
                    badgeToUpdate.DoorNames.Add(doorToAdd);
                    break;
            }
        }

        private void AddABadge()
        {
            Console.Clear();

            Console.WriteLine("What is the number on the Badge: ");
            int badgeID = int.Parse(Console.ReadLine());

            List<string> doorNames = AddListOfDoors();

            Badge newBadge = new Badge(badgeID, doorNames);
            _badgeRepo.AddBadgeToDictionary(newBadge);
        }

        public List<string> AddListOfDoors()
        {
            List<string> doorNames = new List<string>();
            bool stillAdding = true;
            while (stillAdding)
            {
                Console.WriteLine("List a door that it needs access to: ");
                string userInput = Console.ReadLine();
                doorNames.Add(userInput);

                Console.WriteLine("Any other doors(y/n)?");
                if (Console.ReadLine().ToLower() == "y")
                {
                    stillAdding = true;
                }
                else
                {
                    stillAdding = false;
                }
            }
            return doorNames;
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Hello Security Admin, What would you like to do?\n");

            Console.WriteLine("1. Add a Badge\n" +
                              "2. Edit a Badge\n" +
                              "3. List all Badges");
        }

        public void SeedBadges()
        {
            Badge badge1 = new Badge(1, new List<string> { "Door1", "Door2" });
            Badge badge2 = new Badge(2, new List<string> { "Door2", "Door3" });
            _badgeRepo.AddBadgeToDictionary(badge1);
            _badgeRepo.AddBadgeToDictionary(badge2);
        }

        /* public void UpdateBadgeMenu()
         {
             Console.WriteLine("What would you like to do?\n" +
                               "\n" +
                               "1. Remove a door\n" +
                               "2. Add a door");

             switch (Console.ReadLine())
             {
                 case "1":
                     RemoveDoor();
                     break;
                 case "2":
                     AddADoor();
                     break;
             }

         } */

        private void AddADoor()
        {
            throw new NotImplementedException();
        }

        /* private void RemoveDoor()
        {
            Console.WriteLine("Which door would you like to remove?");
            string doorName = Console.ReadLine();
        


        } */

        public void WriteBadgeToConsole(Dictionary<int, List<string>> badgeDictionary)
        {
            foreach (var content in badgeDictionary)
            {
                Console.WriteLine($"Badge: {content.Key}\n" +
                                  $"Has Access to Door(s):");

                WriteContentInListOfStrings(content.Value);

                Console.WriteLine("*****************");
            }
        }

        public void WriteContentInListOfStrings(List<string> stringList)
        {
            foreach (var item in stringList)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}
