using IMS.CoreBusiness.Models;
using IMS.Plugins.SQLite.Data;
using IMS.UseCases.InventoriesUseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

public class SQLiteBaseSourceRepository : ISQLiteBaseSourceRepository
{
    public IMSSQLiteDbContext _context;

    public SQLiteBaseSourceRepository(IMSSQLiteDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Source>> GetAllSourcesAsync()
    {
        return await _context.Sources.ToListAsync();
    }

    public async Task<Source> GetSourceByIdAsync(int sourceId)
    {
        return await _context.Sources.FindAsync(sourceId);
    }

    public async Task AddSourceAsync(Source source)
    {
        _context.Sources.Add(source);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSourceAsync(Source source)
    {
        _context.Entry(source).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteSourceAsync(int sourceId)
    {
        var source = await _context.Sources.FindAsync(sourceId);
        if (source != null)
        {
            _context.Sources.Remove(source);
            await _context.SaveChangesAsync();
        }
    }

    
}
