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
        
        // Create 
        public void AddClaimToList(Claims claim)
        {
            _queueOfClaims.Enqueue(claim);
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
