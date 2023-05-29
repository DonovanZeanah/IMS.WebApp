using System;
using System.Collections.Generic;

namespace BlazorSignalRChartApp.Models;

public partial class LoggerTable
{
    public int LoggerId { get; set; }

    public int CarId { get; set; }

    public string TypeLogger { get; set; } = null!;

    public int NumLoggers { get; set; }

    public virtual CarTable Car { get; set; } = null!;
}
