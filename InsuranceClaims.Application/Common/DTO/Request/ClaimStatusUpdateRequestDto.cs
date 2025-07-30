using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaims.Application.Common.DTO.Request
{
    public class ClaimStatusUpdateRequestDto
    {
        public string Status { get; set; } = "Pending";
    }
}
