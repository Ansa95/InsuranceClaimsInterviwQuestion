using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaims.Domain.Entities
{
    public class Policy
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; } = string.Empty;
        public string PolicyName { get; set; } = string.Empty;
        public string CoverageDetails { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PremiumAmount { get; set; }

        public ICollection<PolicyPolicyholder> PolicyPolicyholders { get; set; } = new List<PolicyPolicyholder>();
        public ICollection<Claim>? Claims { get; set; }
    }
}
