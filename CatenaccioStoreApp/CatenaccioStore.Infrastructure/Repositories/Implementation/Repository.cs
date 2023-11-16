using CatenaccioStore.Infrastructure.Repositories.Abstraction;
using CatenaccioStore.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace CatenaccioStore.Infrastructure.Repositories.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public IQueryable<T> Table => _dbSet;

        public async Task<IEnumerable<T>> GetCollectionAsync(CancellationToken token, Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? await _context.Set<T>().ToListAsync(token).ConfigureAwait(false) : await _context.Set<T>().Where(expression).ToListAsync(token).ConfigureAwait(false);
        }

        public IQueryable<T> GetQuery(Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? _context.Set<T>() : _context.Set<T>().Where(expression);
        }

        public async Task AddAsync(T entity, CancellationToken token)
        {
            await _dbSet.AddAsync(entity, token);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken token)
        {
            return await _dbSet.AnyAsync(predicate, token);
        }

        public async Task RemoveAsync(CancellationToken token, params object[] key)
        {
            var entity = await _dbSet.FindAsync(key, token);
            _dbSet.Remove(entity);
        }
        public void Update(T entity, CancellationToken token)
        {
            if (entity == null)
                return;
            _dbSet.Update(entity);
        }
    }
}
