using InsuranceClaims.Application.Common.DTO.Request;
using InsuranceClaims.Application.Common.DTO.Response;
using InsuranceClaims.Application.Common.Interfaces.IServices;
using InsuranceClaims.Application.Common.Interfaces.Persistance;
using InsuranceClaims.Application.Common.Utilities;
using InsuranceClaims.Domain.Constant;
using InsuranceClaims.Domain.Entities;

namespace InsuranceClaims.Infrastructure.Services
{
    public class ClaimService: IClaimService
    {
        private readonly IClaimRepository _claimRepository;

        public ClaimService(IClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }

        public async Task<ClaimResponseDto?> GetClaimByIdAsync(int id)
        {
            var claim = await _claimRepository.GetByIdAsync(id);
            if (claim == null) return null;

            return MapToResponseDto(claim);
        }

        public async Task<PaginatedList<ClaimResponseDto>> GetClaimsForPolicyholderPagedAsync(ClaimFilterRequestDto filter)
        {
            // Filter claims by policyholder
            var pagedClaims = await _claimRepository.GetClaimsForPolicyholderPagedAsync(filter);

            var dtoList = pagedClaims.Items.Select(MapToResponseDto).ToList();

            return new PaginatedList<ClaimResponseDto>(
                dtoList,
                pagedClaims.TotalCount,
                pagedClaims.Page,
                pagedClaims.PerPage
            );
        }

       
        public async Task UpdateClaimStatusAsync(int id, string status)
        {
            var claim = await _claimRepository.GetByIdAsync(id);
            if (claim == null) throw new KeyNotFoundException("Claim not found");

            if (!Enum.TryParse<ClaimStatus>(status, true, out var parsedStatus))
                throw new ArgumentException($"Invalid claim status value: {status}");

            claim.Status = parsedStatus;
            _claimRepository.Update(claim);

            await _claimRepository.SaveChangesAsync();
        }


        public async Task<ClaimResponseDto> SubmitClaimAsync(ClaimRequestDto claimRequest)
        {
            var claim = new Claim
            {
                PolicyholderId = claimRequest.PolicyholderId,
                PolicyId = claimRequest.PolicyId,
                Description = claimRequest.Description,
                ClaimAmount = claimRequest.Amount,
                Status = ClaimStatus.Pending,
                CreatedDate = DateTime.UtcNow,
                SubmittedOn= DateTime.UtcNow,
                SubmittedByUserId= claimRequest.SubmittedByUserId,
                Amount= claimRequest.Amount

                // set other properties as needed
            };

            await _claimRepository.AddAsync(claim);
            await _claimRepository.SaveChangesAsync();

            return MapToResponseDto(claim);
        }

        private ClaimResponseDto MapToResponseDto(Claim claim)
        {
            return new ClaimResponseDto
            {
                Id = claim.Id,
                PolicyholderId = claim.PolicyholderId,
                PolicyId = claim.PolicyId,
                Description = claim.Description,
                Amount = claim.Amount,
                Status = claim.Status.ToString(),
                CreatedDate = claim.CreatedDate
                // map other properties as needed
            };
        }
    }
}
