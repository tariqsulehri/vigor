using System.Collections.Generic;
using ERP.Core.Models.Parties;
using ERP.Core.Models.Party;

namespace ERP.Core.IRepositories.PartyIRepository
{
    public interface ICustomerMachineRepository
    {
        void Add(CustomerMachine customerMachines);
        void Edit(CustomerMachine customerMachines);
        bool Remove(int id);
        CustomerMachine FindById(int id);
        IEnumerable<CustomerMachine> GetAllCustomerMachines();
    }
}
