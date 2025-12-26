using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contract.RepositoryInterfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);

        Task CreateAsync(T entity);
        Task UpdateAsync(T oldEntity, T newEntity);
        Task DeleteAsync(T entity);
        Task<int> SaveChangesAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> exp);
    }
}
