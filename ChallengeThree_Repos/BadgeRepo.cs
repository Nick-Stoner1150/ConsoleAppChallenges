using ChallengeThree_Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThree_Repos
{
    public class BadgeRepo
    {
        Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();
        
        // Create 
        public bool AddBadgeToDictionary (Badge badge)
        {
            if (badge is null)
            {
                return false;
            }

            _badgeDictionary.Add(badge.BadgeID, badge.DoorNames);

            return true;
        }

        // Read 
        public Dictionary<int, List<string>> ShowListOfBadges ()
        {
            foreach (var content in _badgeDictionary)
            {
                return _badgeDictionary;
            }
            return null;
        }

        // Update 
        /* public void AddDoor()
        {

        }

        public void RemoveDoor(string doorToRemove)
        {

        }

        
         /* public void AddDoor(List<string> doorNames)
        {
            Badge oldBadge = GetBadgeByBadgeID(badgeID);

            foreach (var content in _badgeDictionary)
            {
                if (oldBadge.BadgeID == content.Key)
                {
                    content.Value.Add(doorNames);
                }
            }
            return false;
        } */
        // Delete 


        // Helper Methods
        public Badge GetBadgeByBadgeID(int badgeID)
        {
            foreach (var content in _badgeDictionary)
            {
                if (content.Key == badgeID)
                {
                    return new Badge(content.Key, content.Value);
                }
            }
            return null;
        }
    }
}
