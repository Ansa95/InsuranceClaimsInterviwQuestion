using InsuranceClaims.Application.Common.Interfaces.Persistance;
using InsuranceClaims.Infrastructure.Persistance.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaims.Infrastructure.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync() =>
            await _dbSet.ToListAsync();

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate) =>
            await _dbSet.Where(predicate).ToListAsync();


        public async Task<T?> GetByIdAsync(int id) =>
            await _dbSet.FindAsync(id); // Optional string overload

        public async Task AddAsync(T entity) =>
            await _dbSet.AddAsync(entity);

        public async Task AddRangeAsync(IEnumerable<T> entities) =>
            await _dbSet.AddRangeAsync(entities);

        public void Update(T entity) =>
            _dbSet.Update(entity);

        public void Delete(T entity) =>
            _dbSet.Remove(entity);

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate) =>
            await _dbSet.AnyAsync(predicate);

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate) =>
            await _dbSet.CountAsync(predicate);
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }

}
