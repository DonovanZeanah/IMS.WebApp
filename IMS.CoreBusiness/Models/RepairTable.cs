using System;
using System.Collections.Generic;

namespace BlazorSignalRChartApp.Models;

public partial class RepairTable
{
    public int RepairId { get; set; }

    public int CarId { get; set; }

    public int TechnicianId { get; set; }

    public string RepairDetails { get; set; } = null!;

    public DateTime RepairStart { get; set; }

    public DateTime RepairEnd { get; set; }

    public virtual CarTable Car { get; set; } = null!;

    public virtual PlaceholderUserTable Technician { get; set; } = null!;
}
