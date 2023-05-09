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
    public class SearchMercede : ISearchMercede
    {
        private readonly IMercedesRepository _mercedesRepository;

        public SearchMercede(IMercedesRepository mercedesRepository)
        {
            _mercedesRepository = mercedesRepository;
        }
        public IEnumerable<Mercede> Execute(string filter = null)
        {
            return _mercedesRepository.GetMercedes(filter);

        }

        public Mercede Execute(int Id)
        {
            return _mercedesRepository.GetMercede(Id);
        }

       
    }
}
