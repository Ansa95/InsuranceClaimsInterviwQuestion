using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaims.Domain.Entities
{
    public class PolicyPolicyholder
    {
        public int PolicyId { get; set; }
        public Policy? Policy { get; set; }

        public int PolicyholderId { get; set; }
        public Policyholder? Policyholder { get; set; }
    }
}
