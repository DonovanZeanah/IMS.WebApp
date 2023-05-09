using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.CoreBusiness.Models;
using IMS.UseCases.MercedesUseCases.interfaces;
using IMS.UseCases.PluginInterfaces.DataStore;

namespace IMS.UseCases.MercedesUseCases
{
    public class ViewMercede : IViewMercede
    {
        private readonly IMercedesRepository _mercedesRepository;

        public ViewMercede(IMercedesRepository mercedesRepository)
        {
            _mercedesRepository = mercedesRepository;
        }  //CTOR

        public Mercede Execute(int Id)
        {
            return _mercedesRepository.GetMercede(Id);
        }                              //

        public IEnumerable<Mercede> Execute(string filter = null)
        {
            return _mercedesRepository.GetMercedes(filter);
        }   //
    }
}
