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
        static int tableWidth = 73;
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


        // Helper Methods 
        public void WriteListOfClaims(Queue<Claims> claimsQueue)
        {
            foreach (Claims claim in listOfClaims)
            {
                Console.WriteLine(""
            }
        }

    }
}
