using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<T?> GetByGuid(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression);
    }
}
