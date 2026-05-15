using Demo.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastacture.Data
{
    public class Repository<TAggregateRoute, TKey> : IRepository<TAggregateRoute, TKey>
     where TAggregateRoute : class, IAggregateRoute<TKey>
     where TKey : IComparable
    {
        private DbContext _dbContext;
        private DbSet<TAggregateRoute> _dbSet;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TAggregateRoute>();
        }
        public void Add(TAggregateRoute entity)
        {
           _dbSet.Add(entity);
        }

        public async Task AddAsync(TAggregateRoute entity)
        {
            await _dbSet.AddAsync(entity);
        }
    }
}
 