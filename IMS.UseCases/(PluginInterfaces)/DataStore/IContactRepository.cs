using IMS.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases._PluginInterfaces_.DataStore
{
    public interface IContactRepository : IRepository<Contact>
    {
    }

    // IUnitOfWork.cs file
    public interface IUnitOfWork
    {
        IContactRepository Contacts { get; }
    }
}
