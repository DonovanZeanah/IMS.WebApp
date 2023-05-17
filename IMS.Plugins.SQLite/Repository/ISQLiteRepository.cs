using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMS.Plugins.SQLite.Repository
{
    public interface ISQLiteRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
