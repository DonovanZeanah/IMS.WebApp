using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases._PluginInterfaces_.DataStore
{
    public interface IInventory
    {
        int Id { get; set; }
        int InventoryId { get; set; }
        string InventoryName { get; set; }
        int Quantity { get; set; }
        double Price { get; set; }
        int SourceId { get; set; }
        ISource Source { get; set; }
    }
}
