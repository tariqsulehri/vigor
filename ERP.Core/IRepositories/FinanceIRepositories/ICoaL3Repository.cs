using System.Collections.Generic;
using ERP.Core.Models.Finance;

namespace ERP.Core.IRepositories.FinanceIRepositories
{
    public interface ICoaL3Repository
    {
        void Add(CoaL3 coaL3);
        void Edit(CoaL3 l3Code);
        bool Remove(string l3Code);
		bool IsDuplicate(CoaL3 CoaL3);							  
        CoaL3 FindById(string l3Code);
        IEnumerable<CoaL3> GetL3Accounts();
    }
}
