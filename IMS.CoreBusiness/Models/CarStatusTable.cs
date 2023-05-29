using System;
using System.Collections.Generic;

namespace BlazorSignalRChartApp.Models;

public partial class CarStatusTable
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<CarTable> CarTables { get; set; } = new List<CarTable>();
}
