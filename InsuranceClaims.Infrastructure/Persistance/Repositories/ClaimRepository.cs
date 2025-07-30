using InsuranceClaims.Application.Common.DTO.Request;
using InsuranceClaims.Application.Common.Interfaces.Persistance;
using InsuranceClaims.Application.Common.Utilities;
using InsuranceClaims.Domain.Entities;
using InsuranceClaims.Infrastructure.Persistance.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaims.Infrastructure.Persistance.Repositories
{
    public class ClaimRepository: GenericRepository<Claim>, IClaimRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Claim> _dbSet;
        public ClaimRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Claim>();
        }

        public async Task<PaginatedList<Claim>> GetClaimsForPolicyholderPagedAsync(ClaimFilterRequestDto filter)
        {
            var query = _dbSet.AsQueryable();

            // Filter by PolicyholderId
            query = query.Where(c => c.PolicyholderId == filter.PolicyholderId);

            // Search
            if (!string.IsNullOrWhiteSpace(filter.SearchBy))
            {
                query = query.Where(c => c.Description.Contains(filter.SearchBy));
            }

            // Sorting
            query = filter.SortOrder?.ToLower() == "desc"
                ? query.OrderByDescending(c => c.CreatedDate)
                : query.OrderBy(c => c.CreatedDate);
   
            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((filter.Page - 1) * filter.PerPage)
                .Take(filter.PerPage)
                .ToListAsync();

            return new PaginatedList<Claim>(items, totalCount, filter.Page, filter.PerPage);
        }

    }
}
