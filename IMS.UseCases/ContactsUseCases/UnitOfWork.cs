using IMS.UseCases._PluginInterfaces_.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.ContactsUseCases
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IContactRepository contactRepository)
        {
            Contacts = contactRepository;
        }

        public IContactRepository Contacts { get; set; }
    }
}
