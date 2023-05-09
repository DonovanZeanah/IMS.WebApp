using IMS.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.MercedesUseCases.interfaces
{
    public interface ISearchMercede
    {
        Mercede Execute(int Id);
        IEnumerable<Mercede> Execute(string filter = null);

    }
}
