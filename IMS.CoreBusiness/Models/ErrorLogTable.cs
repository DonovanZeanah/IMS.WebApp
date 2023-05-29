using System;
using System.Collections.Generic;

namespace BlazorSignalRChartApp.Models;

public partial class ErrorLogTable
{
    public int ErrorId { get; set; }

    public int CarId { get; set; }

    public string? ErrorDetails { get; set; }

    public int? ErrorPriority { get; set; }

    public string? ErrorNotes { get; set; }

    public virtual CarTable Car { get; set; } = null!;
}
