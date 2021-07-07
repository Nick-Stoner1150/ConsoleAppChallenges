using ChallengeTwo_POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Repos
{
    public class ClaimsRepo
    {
        private List<Claims> _listOfClaims = new List<Claims>();

        // Create 
        public void AddClaimToList(Claims claim)
        {
            _listOfClaims.Add(claim);
        }

        // Read 
        public List<Claims> ShowClaimsList()
        {
            return _listOfClaims;
        }
    }
}
