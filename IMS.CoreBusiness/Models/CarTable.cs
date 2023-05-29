using System;
using System.Collections.Generic;

namespace BlazorSignalRChartApp.Models;

public partial class CarTable
{
    public int CarId { get; set; }

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int Year { get; set; }

    public string TeleGeneration { get; set; } = null!;

    public int Miles { get; set; }

    public string? Location { get; set; }

    public int CurrentStatusId { get; set; }

    public int SourceId { get; set; }

    public virtual CarDetailsTable? CarDetailsTable { get; set; }

    public virtual CarStatusTable CurrentStatus { get; set; } = null!;

    public virtual ICollection<ErrorLogTable> ErrorLogTables { get; set; } = new List<ErrorLogTable>();

    public virtual ICollection<EventTable> EventTables { get; set; } = new List<EventTable>();

    public virtual ICollection<LoggerTable> LoggerTables { get; set; } = new List<LoggerTable>();

    public virtual ICollection<RepairTable> RepairTables { get; set; } = new List<RepairTable>();

    public virtual ICollection<SoftwareTable> SoftwareTables { get; set; } = new List<SoftwareTable>();

    public virtual SourceTable Source { get; set; } = null!;
}
