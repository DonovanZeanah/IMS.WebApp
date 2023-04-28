using System.Collections.Generic;
using System.Threading.Tasks;
using IMS.CoreBusiness.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.SQLite
{
    public class SQLiteRepository<T> : ISQLiteRepository<T> where T : class
    {
        private readonly IMSSQLiteDbContext _dbContext;

        public SQLiteRepository(IMSSQLiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
