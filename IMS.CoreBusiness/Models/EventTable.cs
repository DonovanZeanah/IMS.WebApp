using System;
using System.Collections.Generic;

namespace BlazorSignalRChartApp.Models;

public partial class EventTable
{
    public int EventId { get; set; }

    public int CarId { get; set; }

    public int UserId { get; set; }

    public int EventTypeId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public virtual CarTable Car { get; set; } = null!;

    public virtual EventTypeTable EventType { get; set; } = null!;

    public virtual PlaceholderUserTable User { get; set; } = null!;
}
