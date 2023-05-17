using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.CoreBusiness.Models
{
    public class InventorySource
    {
        public int InventoryId { get; set; }
        //public Inventory? Inventory { get; set; }

       public ICollection<Inventory>? Inventories { get; set; }

        public int SourceId { get; set; }
       // public Source? Source { get; set; }

         public ICollection<Source> Sources { get; set; }
    }

}

