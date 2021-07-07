using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_POCO
{
    public class Claims
    {
        public int ClaimID { get; set; }
        public enum ClaimType 
        {
            Car = 1,
            Home, 
            Theft
        }
        public ClaimType Type;
        public string Descripion { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claims ()
        {

        }

        public Claims (int claimID, ClaimType type, string description, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValid)
        {
            this.ClaimID = claimID;
            this.Type = type;
            this.Descripion = description;
            this.ClaimAmount = claimAmount;
            this.DateOfIncident = dateOfIncident;
            this.DateOfClaim = dateOfClaim;
            this.IsValid = isValid;
        }

    }
}
