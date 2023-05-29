using System;
using System.Collections.Generic;

namespace BlazorSignalRChartApp.Models;

public partial class PlaceholderUserTable
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual ICollection<EventTable> EventTables { get; set; } = new List<EventTable>();

    public virtual ICollection<RepairTable> RepairTables { get; set; } = new List<RepairTable>();

    public virtual PlaceholderUserRoleTable Role { get; set; } = null!;
}
