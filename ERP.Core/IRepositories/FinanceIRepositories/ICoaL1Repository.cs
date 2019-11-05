using System.Collections.Generic;
using ERP.Core.Models.Finance;

namespace ERP.Core.IRepositories.FinanceIRepositories

{
    public interface ICoaL1Repository
    {
        void Add(CoaL1 coaL1);
        void Edit(CoaL1 l1Code);
        bool Remove(string l1Code);
		 bool IsDuplicate(CoaL1 coaL1);							  
        CoaL1 FindById(string l1Code);
        IEnumerable<CoaL1> GetL1Accounts();
    }
}
