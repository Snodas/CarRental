using CarRental.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarRental.Data.Repositories
{
    public abstract class GenericRepository<T, TContext> : IRepository<T>
            where T : class, IEntity
            where TContext : DbContext
    {
        protected TContext dbContext;

        public GenericRepository(TContext context)
        {
            dbContext = context;
        }
       
        public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return dbContext.Set<T>().FirstOrDefault(predicate);
        } 
        
        public virtual async Task<T?> GetAsync(int id)
        {
            return await dbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T?> AddAsync(T entity)
        {
            var added = dbContext.Set<T>().Add(entity);
            await dbContext.SaveChangesAsync();

            return added.Entity;
        }

        public async Task<IEnumerable<T>?> AllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task RemoveAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbContext.Set<T>().AnyAsync(predicate);
        }

        public async Task UpdateAsync(T entity)
        {
            dbContext.Set<T>().Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
