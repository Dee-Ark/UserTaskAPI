using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserTaskShared.Respository.Implementation;

namespace UserTaskShared.Respository
{
    public class RepositoryService<T> : IRepositoryService<T> where T : class
    {
        protected internal readonly DbContext _context;

        public RepositoryService(DbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddAsync(T model)
        {
            await _context.Set<T>().AddAsync(model).ConfigureAwait(false);
        }

        public async Task AddRangeAsync(IReadOnlyList<T> models)
        {
            await _context.Set<T>().AddRangeAsync(models).ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync().ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includes != null)
            {
                foreach (var property in includes)
                {
                    query = query.Include(property);
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return await query.ToListAsync().ConfigureAwait(false);
        }

        public async Task<T> GetAsync(long id)
        {
            return await _context.Set<T>().FindAsync(id).ConfigureAwait(false);
        }

        public async Task<T> GetAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            if (includes != null)
            {
                foreach (var property in includes)
                {
                    query = query.Include(property);
                }
            }
            if (orderBy != null) query = orderBy(query);
            return await query.FirstOrDefaultAsync(predicate).ConfigureAwait(false);
        }


        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AsNoTracking().AnyAsync(predicate).ConfigureAwait(false);
        }


        public void Remove(T model)
        {
            if (_context.Entry(model).State == EntityState.Detached)
            {
                _context.Set<T>().Attach(model);
            }
            _context.Set<T>().Remove(model);
        }

        public void Remove(long id)
        {
            var model = _context.Set<T>().Find(id);
            if (_context.Entry(model).State == EntityState.Detached)
            {
                _context.Set<T>().Attach(model);
            }
            _context.Set<T>().Remove(model);
        }

        public async Task RemoveAsync(Expression<Func<T, bool>> predicate)
        {
            var model = await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(predicate).ConfigureAwait(false);
            if (_context.Entry(model).State == EntityState.Detached)
            {
                _context.Set<T>().Attach(model);
            }
            _context.Set<T>().Remove(model);
        }

        public async Task RemoveRangeAsync(Expression<Func<T, bool>> predicate)
        {
            var models = await _context.Set<T>().AsNoTracking().Where(predicate).ToListAsync().ConfigureAwait(false);
            foreach (var model in models)
            {
                //if (_context.Entry(model).State == EntityState.Detached)
                //{
                _context.Set<T>().Remove(model);
                //_context.Set<T>().Attach(model);
                //}
            }
            // _context.Set<T>().RemoveRange(models);
            // _context.ChangeTracker.DetectChanges();
        }

        public void Update(T model)
        {
            _context.Update(model);
        }
        public Task<int> CountAll() => _context.Set<T>().CountAsync();

        public Task<int> CountWhere(Expression<Func<T, bool>> predicate)
            => _context.Set<T>().CountAsync(predicate);

        public IQueryable<T> GetQueryable()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>,
            IOrderedQueryable<T>>? orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            if (includes != null)
            {
                foreach (var property in includes)
                {
                    query = query.Include(property);
                }
            }
            if (orderBy != null) query = orderBy(query);
            return await query.FirstOrDefaultAsync(predicate).ConfigureAwait(false);
        }

        public async Task<IReadOnlyList<T>> GetAllPagenatedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            if (pageNumber == 0) pageNumber = 1;
            IQueryable<T> query = _context.Set<T>().AsNoTracking();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includes != null)
            {
                foreach (var property in includes)
                {
                    query = query.Include(property);
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return await query.Skip(pageNumber - 1).Take(pageSize).ToListAsync().ConfigureAwait(false);
        }

        public void UpdateRange(List<T> models)
        {
            _context.Set<T>().UpdateRange(models);
        }

        public void Clear()
        {
            _context.ChangeTracker.Clear();
        }
    }
}
