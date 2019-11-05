using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Parties;

namespace ERP.Core.IRepositories.PartyIRepository
{
    public interface ICustomerInstructionRepository
    {
        void Add(CustomerInstruction customerInstruction);
        void Edit(CustomerInstruction customerInstruction);
        bool Remove(int id);
        CustomerInstruction FindById(int id);
        IEnumerable<CustomerInstruction> GetAllCustomerInstruction();
    }
}
