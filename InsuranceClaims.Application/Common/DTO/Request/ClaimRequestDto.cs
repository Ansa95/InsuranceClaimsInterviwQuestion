using InsuranceClaims.Domain.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaims.Application.Common.DTO.Request
{
    public class ClaimRequestDto
    {
        public int PolicyholderId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateFiled { get; set; }
        public ClaimStatus Status { get; set; }
        public int PolicyId { get; set; }
        public int SubmittedByUserId { get; set; }
    }
}
