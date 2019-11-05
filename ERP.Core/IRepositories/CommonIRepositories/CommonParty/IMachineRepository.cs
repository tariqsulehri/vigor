using System.Collections.Generic;
using ERP.Core.Models.Common.Party;

namespace ERP.Core.IRepositories.CommonIRepositories.CommonParty
{
    public interface IMachineRepository
    {
        void Add(Machine machine);
        void Edit(Machine machine);
        bool Remove(int id);
        Machine FindById(int id);
        bool IsDuplicate(Machine machine);
        IEnumerable<Machine> GetAllMachines();
    }
}
