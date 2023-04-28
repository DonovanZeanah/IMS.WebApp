using IMS.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases._PluginInterfaces_.DataStore
{
    public interface ISource
    {
        int Id { get; set; }
        string Name { get; set; }
        ICollection<Inventory> Inventories { get; set; }
    }
}
