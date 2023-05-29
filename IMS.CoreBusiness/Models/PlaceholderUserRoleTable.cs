using System;
using System.Collections.Generic;

namespace BlazorSignalRChartApp.Models;

public partial class PlaceholderUserRoleTable
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<PlaceholderUserTable> PlaceholderUserTables { get; set; } = new List<PlaceholderUserTable>();
}
