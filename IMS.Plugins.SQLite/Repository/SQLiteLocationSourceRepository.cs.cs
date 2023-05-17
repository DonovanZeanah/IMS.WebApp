using IMS.CoreBusiness.Models;
using IMS.Plugins.SQLite.Data;
using IMS.UseCases.InventoriesUseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IMS.Plugins.SQLite.Repository
{

    public class SQLiteLocationSourceRepository : SQLiteBaseSourceRepository
    {
        public SQLiteLocationSourceRepository(IMSSQLiteDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<LocationSource>> GetAllLocationSourcesAsync()
        {
            return await _context.LocationSources.ToListAsync();
        }

        public async Task<LocationSource> GetLocationSourceByIdAsync(int sourceId)
        {
            return await _context.LocationSources.FindAsync(sourceId);
        }

        public async Task AddLocationSourceAsync(LocationSource source)
        {
            _context.LocationSources.Add(source);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLocationSourceAsync(LocationSource source)
        {
            _context.Entry(source).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLocationSourceAsync(int sourceId)
        {
            var source = await _context.LocationSources.FindAsync(sourceId);
            if (source != null)
            {
                _context.LocationSources.Remove(source);
                await _context.SaveChangesAsync();
            }
        }
    }
}