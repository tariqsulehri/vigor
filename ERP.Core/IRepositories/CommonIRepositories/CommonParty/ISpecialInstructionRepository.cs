using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Common.Party;

namespace ERP.Core.IRepositories.CommonIRepositories.CommonParty
{
    public interface ISpecialInstructionRepository
    {
        void Add(SpecialInstruction sepcialInstruction);
        void Edit(SpecialInstruction sepcialInstruction);
        bool Remove(int id);
        SpecialInstruction FindById(int id);

        bool IsDuplicate(SpecialInstruction specialInstruction);
        IEnumerable<SpecialInstruction> GetAllSpecialInstructions();
    }
}
