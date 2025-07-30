using InsuranceClaims.Domain.Constant;
using InsuranceClaims.Domain.Entities;
using InsuranceClaims.Infrastructure.Persistance.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaims.Infrastructure
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            // Prevent duplicate seed
            if (context.Claims.Any()) return;

            var user = new User
            {
                Username = "hospital1",
                PasswordHash = "hashed-password", // hash if real
                Role = "Hospital"
            };

            var policyholder = new Policyholder
            {
                FullName = "John Doe",
                ContactInfo = "john@example.com"
            };

            var policy = new Policy
            {
                PolicyNumber = "P123456",
                PolicyName = "Health Policy A",
                CoverageDetails = "Covers hospitalization",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddYears(1),
                PremiumAmount = 1000m
            };

            var claim = new Claim
            {
                Policy = policy,
                Policyholder = policyholder,
                SubmittedByUser = user,
                ClaimAmount = 500m,
                Status = ClaimStatus.Pending,
                SubmittedOn = DateTime.UtcNow,
                Description = "Hospitalization due to accident",
                CreatedDate = DateTime.UtcNow
            };

            context.Claims.Add(claim);
            await context.SaveChangesAsync();
        }
    }

}
