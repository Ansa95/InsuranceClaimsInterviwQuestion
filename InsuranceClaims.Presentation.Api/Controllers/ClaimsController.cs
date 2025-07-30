using InsuranceClaims.Application.Common.DTO.Request;
using InsuranceClaims.Application.Common.Interfaces.IServices;
using InsuranceClaims.Domain.Constant;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceClaims.Presentation.Api.Controllers
{
    /// <summary>
    /// Handles operations related to insurance claims.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimService _claimService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimsController"/> class.
        /// </summary>
        /// <param name="claimService">The service for claim operations.</param>
        public ClaimsController(IClaimService claimService)
        {
            _claimService = claimService;
        }

        #region Get Methods

        /// <summary>
        /// Retrieves a claim by its ID.
        /// </summary>
        /// <param name="id">The ID of the claim.</param>
        /// <returns>The requested claim or NotFound if it doesn't exist.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClaim(int id)
        {
            var claim = await _claimService.GetClaimByIdAsync(id);
            if (claim == null) return NotFound();
            return Ok(claim);
        }

        #endregion

        #region Put Methods

        /// <summary>
        /// Updates the status of an existing claim.
        /// </summary>
        /// <param name="id">The ID of the claim.</param>
        /// <param name="request">The status update request.</param>
        /// <returns>No content if successful.</returns>
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateClaimStatus(int id, [FromBody] ClaimStatusUpdateRequestDto request)
        {
            await _claimService.UpdateClaimStatusAsync(id, request.Status);
            return Ok();
           
        }

        #endregion

        #region Post Methods

        /// <summary>
        /// Submits a new insurance claim.
        /// </summary>
        /// <param name="claim">The claim object to submit.</param>
        /// <returns>The created claim with location header.</returns>
        [HttpPost]
        public async Task<IActionResult> SubmitClaim([FromBody] ClaimRequestDto claim)
        {
            var createdClaim = await _claimService.SubmitClaimAsync(claim);
            return CreatedAtAction(nameof(GetClaim), new { id = createdClaim.Id }, createdClaim);
        }


        [HttpPost("policyholder/claims")]
        public async Task<IActionResult> GetClaimsForPolicyholder([FromBody] ClaimFilterRequestDto claimRequest)
        {
            var claims = await _claimService.GetClaimsForPolicyholderPagedAsync(
                claimRequest);

            return Ok(claims);
        }


        #endregion
    }


}
