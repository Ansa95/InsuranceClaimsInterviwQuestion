using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaims.Application.Common.DTO.Response
{
    public class ClaimResponseDto
    {
        public int Id { get; set; }
        public int PolicyholderId { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Status { get; set; } = string.Empty;
        public int PolicyId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
