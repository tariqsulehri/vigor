using System.Collections.Generic;
using ERP.Core.Models.Finance;

namespace ERP.Core.IRepositories.FinanceIRepositories
{
    public interface ICoaL2Repository
    {
        void Add(CoaL2 coaL2);
        void Edit(CoaL2 l2Code);
        bool Remove(string l2Code);
		 bool IsDuplicate(CoaL2 coaL2);							  
        CoaL2 FindById(string l2Code);
        IEnumerable<CoaL2> GetL2Accounts();
    }
}
