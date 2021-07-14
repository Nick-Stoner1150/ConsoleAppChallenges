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
        public void AddBadgeToDictionary (Badge badge)
        {
            _badgeDictionary.Add(badge.BadgeID, badge.DoorNames);
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
        /* public bool UpdateBadge(int badgeID, Badge newBadge)
        {
            Badge oldBadge = GetBadgeByBadgeID(badgeID);

            foreach (var content in _badgeDictionary)
            {
                if (oldBadge.BadgeID == content.Key)
                {
                    
                }
            }
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

        public string GetDoorName (string doorName)
        {
            foreach (var content in _badgeDictionary)
            {
                foreach (var item in content.Value)
                {
                    if (item == doorName)
                    {
                        return item;
                    }
                }
            }
            return null;
        }
    }
}
