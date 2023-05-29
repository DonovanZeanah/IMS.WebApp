using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Models
{
    public class EventDetail
    {
        public int Id { get; set; } // Primary Key
        public string ErrorNotes { get; set; }
        public int PriorityLevel { get; set; }

        // Foreign Key for Event
        public int EventId { get; set; }
        public Event Event { get; set; } // Navigation property
    }
}
