using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BAL;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _entities;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task Add(T entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _entities.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _entities.Remove(entity);
        }

        public async Task<T?> GetByGuid(Guid id) => await _entities.FindAsync(id);

        public void Update(T entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _entities.Update(entity);
        }

        public async Task<IEnumerable<T>> GetAll() => await _entities.ToListAsync();

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            if (expression == null)
            {
                throw new InvalidOperationException(nameof(expression));
            }

            return await _entities.Where(expression).ToListAsync();
        }
    }
}
