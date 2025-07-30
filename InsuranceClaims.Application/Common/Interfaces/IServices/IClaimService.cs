using InsuranceClaims.Application.Common.DTO.Request;
using InsuranceClaims.Application.Common.DTO.Response;
using InsuranceClaims.Application.Common.Utilities;
using InsuranceClaims.Domain.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaims.Application.Common.Interfaces.IServices
{
    public interface IClaimService
    {
        Task<ClaimResponseDto?> GetClaimByIdAsync(int id);

        Task<PaginatedList<ClaimResponseDto>> GetClaimsForPolicyholderPagedAsync(ClaimFilterRequestDto filter);

        Task UpdateClaimStatusAsync(int id, string status);

        Task<ClaimResponseDto> SubmitClaimAsync(ClaimRequestDto claimRequest);
    }
}
