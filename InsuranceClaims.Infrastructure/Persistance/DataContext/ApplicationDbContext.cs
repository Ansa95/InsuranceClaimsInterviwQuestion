
using InsuranceClaims.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InsuranceClaims.Infrastructure.Persistance.DataContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Policyholder> Policyholders { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<PolicyPolicyholder> PolicyPolicyholders { get; set; }
        public DbSet<Claim> Claims { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Composite key for join table
            modelBuilder.Entity<PolicyPolicyholder>()
                .HasKey(pp => new { pp.PolicyId, pp.PolicyholderId });

            // Configure relationships
            modelBuilder.Entity<PolicyPolicyholder>()
                .HasOne(pp => pp.Policy)
                .WithMany(p => p.PolicyPolicyholders)
                .HasForeignKey(pp => pp.PolicyId);

            modelBuilder.Entity<PolicyPolicyholder>()
                .HasOne(pp => pp.Policyholder)
                .WithMany(ph => ph.PolicyPolicyholders)
                .HasForeignKey(pp => pp.PolicyholderId);

            // Unique index for PolicyNumber in Policy
            modelBuilder.Entity<Policy>()
                .HasIndex(p => p.PolicyNumber)
                .IsUnique();

            // Unique index for Username in User
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // Relationships in Claim
            modelBuilder.Entity<Claim>()
                .HasOne(c => c.Policy)
                .WithMany(p => p.Claims)
                .HasForeignKey(c => c.PolicyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Claim>()
                .HasOne(c => c.Policyholder)
                .WithMany(ph => ph.Claims)
                .HasForeignKey(c => c.PolicyholderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Claim>()
                .HasOne(c => c.SubmittedByUser)
                .WithMany(u => u.SubmittedClaims)
                .HasForeignKey(c => c.SubmittedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Claim>()
            .Property(c => c.Status)
            .HasConversion<string>();

            var seedStartDate = new DateTime(2024, 01, 01);
            var seedEndDate = new DateTime(2025, 01, 01);
            var seedSubmittedOn = new DateTime(2024, 06, 01);
            var seedCreatedDate = new DateTime(2024, 06, 01);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Username = "hospital1",
                PasswordHash = "hashed-password",
                Role = "Hospital"
            });

            modelBuilder.Entity<Policyholder>().HasData(new Policyholder
            {
                Id = 1,
                FullName = "John Doe",
                ContactInfo = "john@example.com"
            });

            modelBuilder.Entity<Policy>().HasData(new Policy
            {
                Id = 1,
                PolicyNumber = "P123456",
                PolicyName = "Health Policy A",
                CoverageDetails = "Covers hospitalization",
                StartDate = seedStartDate,
                EndDate = seedEndDate,
                PremiumAmount = 1000m
            });
            

            modelBuilder.Entity<Claim>().HasData(new Claim
            {
                Id = 1,
                PolicyId = 1,
                PolicyholderId = 1,
                SubmittedByUserId = 1,
                ClaimAmount = 500m,
                Status = Domain.Constant.ClaimStatus.Pending,
                SubmittedOn = seedSubmittedOn,
                Description = "Hospitalization due to accident",
                CreatedDate = seedCreatedDate,
                UpdatedOn = null,
                Amount = 500m
            });
        }
    }
}

