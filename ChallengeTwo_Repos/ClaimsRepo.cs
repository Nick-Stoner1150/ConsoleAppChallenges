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
        private Queue<Claims> _queueOfClaims = new Queue<Claims>();
        private int _idCounter;

        // Create 
        public bool AddClaimToList(Claims claim)
        {
            if (claim is null)
            {
                return false;
            }

            claim.ClaimID = ++_idCounter;
            _queueOfClaims.Enqueue(claim);

            return true;
        }

        // Read 
        public Queue<Claims> ShowClaimsList()
        {
            return _queueOfClaims;
        }

        // Peek In Queue 
        public Claims PeekNextClaim()
        {
            Claims peekedClaim = _queueOfClaims.Peek();
            return peekedClaim;
        }

        public Claims DequeueClaim ()
        {
            Claims dequeuedClaim = _queueOfClaims.Dequeue();
            return dequeuedClaim;
        }
    }
}
