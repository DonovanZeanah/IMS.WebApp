using System;
using System.Collections.Generic;

namespace BlazorSignalRChartApp.Models;

public partial class EventTypeTable
{
    public int EventTypeId { get; set; }

    public string EventTypeName { get; set; } = null!;

    public virtual ICollection<EventTable> EventTables { get; set; } = new List<EventTable>();
}
