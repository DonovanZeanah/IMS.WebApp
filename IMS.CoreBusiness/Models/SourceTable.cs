using System;
using System.Collections.Generic;

namespace BlazorSignalRChartApp.Models;

public partial class SourceTable
{
    public int SourceId { get; set; }

    public string SourceName { get; set; } = null!;

    public string SourceType { get; set; } = null!;

    public virtual ICollection<CarTable> CarTables { get; set; } = new List<CarTable>();
}
