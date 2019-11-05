using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Parties;

namespace ERP.Core.IRepositories.PartyIRepository
{
    public interface ICustomerContactPersonRepository
    {
        void Add(CustomerContactPerson customerContactPersons);
        void Edit(CustomerContactPerson customerContactPersons);
        bool Remove(int id);
        CustomerContactPerson FindById(int id);
        IEnumerable<CustomerContactPerson> GetAllContactPersons();
    }
}
