using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaims.Application.Common.DTO.Request
{
    public class ClaimFilterRequestDto
    {
        public int PolicyholderId { get; set; }
        public int Page { get; set; } = 1;

        // Number of items per page
        public int PerPage { get; set; } = 10;

        public string SortOrder { get; set; } = "asc"; // or "desc"
        public string? SearchBy { get; set; } = null;
    }
}
