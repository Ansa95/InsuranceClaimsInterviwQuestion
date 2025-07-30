using InsuranceClaims.Application.Common.DTO.Request;
using InsuranceClaims.Application.Common.Utilities;
using InsuranceClaims.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaims.Application.Common.Interfaces.Persistance
{
    public interface IClaimRepository :IGenericRepository<Claim>
    {

        Task<PaginatedList<Claim>> GetClaimsForPolicyholderPagedAsync(ClaimFilterRequestDto filter);
    }
    
}
