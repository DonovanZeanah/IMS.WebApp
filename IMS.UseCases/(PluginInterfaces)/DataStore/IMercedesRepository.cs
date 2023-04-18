using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.CoreBusiness.Models;

namespace IMS.UseCases.PluginInterfaces.DataStore
{
    public interface IMercedesRepository
    {
        Mercede GetMercede(int id);
        IEnumerable<Mercede> GetMercedes(string filter = null);
    }
}
