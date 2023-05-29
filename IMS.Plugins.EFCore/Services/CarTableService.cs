


using BlazorSignalRChartApp.Models;
using Microsoft.EntityFrameworkCore;
using IMS.CoreBusiness.Models;

namespace IMS.WebApp.Pages
{
    public class CarTableService
    {
        private readonly T4Context _context;

        public CarTableService(T4Context context)
        {
            _context = context;
        }

        public IList<CarTable> CarTable { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CarTables != null)
            {
                CarTable = await _context.CarTables
                    .Include(c => c.CurrentStatus)
                    .Include(c => c.Source).ToListAsync();
            }
        }
    }
}