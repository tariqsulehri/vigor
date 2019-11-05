using System.Collections.Generic;
using ERP.Core.Models.Parties;
using ERP.Core.Models.Party;

namespace ERP.Core.IRepositories.FinPartiesIRepository
{
    public interface IFinPartyRepository
    {
        void Add(FinParty finParty);
        void Edit(FinParty finParty);
		  bool IsDuplicate(FinParty finParty);									
        bool Remove(int id);
        FinParty FindById(int id);
        IEnumerable<FinParty> GetAllParties();
    }
}
