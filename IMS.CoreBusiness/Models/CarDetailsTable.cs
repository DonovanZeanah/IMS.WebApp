using System;
using System.Collections.Generic;

namespace BlazorSignalRChartApp.Models;

public partial class CarDetailsTable
{
    public int CarId { get; set; }

    public string Tag { get; set; } = null!;

    public string Finas { get; set; } = null!;

    public string Vinlast4 { get; set; } = null!;

    public string? HarnessStatus { get; set; }

    public string? FullVin { get; set; }

    public virtual CarTable Car { get; set; } = null!;
}
