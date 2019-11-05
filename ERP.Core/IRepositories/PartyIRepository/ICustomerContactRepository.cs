using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Parties;
using ERP.Core.Models.Party;

namespace ERP.Core.IRepositories.PartyIRepository
{
    public interface ICustomerContactRepository
    {
        void Add(CustomerContact customerContact);
        void Edit(CustomerContact customerContact);
        bool Remove(int id);
        CustomerContact FindById(int id);
        IEnumerable<CustomerContact> GetAllCustomerContact();
    }
}
