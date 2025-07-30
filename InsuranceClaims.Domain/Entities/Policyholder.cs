using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaims.Domain.Entities
{
    public class Policyholder
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;

        public ICollection<PolicyPolicyholder> PolicyPolicyholders { get; set; } = new List<PolicyPolicyholder>();
        public ICollection<Claim>? Claims { get; set; }
    }
}
