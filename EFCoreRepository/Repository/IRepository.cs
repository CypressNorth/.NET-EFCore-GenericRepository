using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreRepository.Repository
{
    public interface IRepository<T> where T : class
    {
        T Get(object id);
        IQueryable<T> GetAll();
        void Insert(T entity);
        void InsertAll(ICollection<T> range);
        Task InsertAllAsync(ICollection<T> range);
        Task InsertAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
