using InsuranceClaims.Domain.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaims.Domain.Entities
{
    public class Claim
    {
        public int Id { get; set; }

        public int PolicyId { get; set; }
        public Policy? Policy { get; set; }

        public int PolicyholderId { get; set; }
        public Policyholder? Policyholder { get; set; }

        public decimal ClaimAmount { get; set; }
        public ClaimStatus Status { get; set; } = ClaimStatus.Pending;
        public DateTime SubmittedOn { get; set; } = DateTime.UtcNow;
        public string Description { get; set; } = string.Empty;

        public int SubmittedByUserId { get; set; }
        public User? SubmittedByUser { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Amount { get; set; }
    }
}
