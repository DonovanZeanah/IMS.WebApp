using System;
using System.Collections.Generic;

namespace BlazorSignalRChartApp.Models;

public partial class SoftwareTable
{
    public int SoftwareId { get; set; }

    public int CarId { get; set; }

    public string HeadUnit { get; set; } = null!;

    public string SoftwareVersion { get; set; } = null!;

    public string NextSoftwareVersion { get; set; } = null!;

    public virtual CarTable Car { get; set; } = null!;
}
