using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.CoreBusiness.Models;

namespace IMS.UseCases.MercedesUseCases.interfaces
{
    public interface IViewMercede
    {
        Mercede Execute(int Id);
        IEnumerable<Mercede> Execute(string filter = null);

    }
}
