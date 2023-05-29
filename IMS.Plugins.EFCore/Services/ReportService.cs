using IMS.CoreBusiness.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Plugins.EFCore.Services
{
    public class ReportService
    {
        private readonly IMSContext _context;

        public ReportService(IMSContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EventDetail>> GetTestDriveErrorsAsync()
        {
            return await _context.EventDetails
                .Include(ed => ed.Event)
                .Where(ed => ed.Event.EventType == "Test Drive" && ed.ErrorNotes != null)
                .OrderBy(ed => ed.PriorityLevel)
                .ToListAsync();
        }
    }

    
}
