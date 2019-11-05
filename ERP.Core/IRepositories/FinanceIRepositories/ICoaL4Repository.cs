using System.Collections.Generic;
using ERP.Core.Models.Finance;

namespace ERP.Core.IRepositories.FinanceIRepositories
{
    public interface ICoaL4Repository
    {
        void Add(CoaL4 coaL4);
        void Edit(CoaL4 l4Code);
        bool Remove(string l4Code);
		 bool IsDuplicate(CoaL4 coaL4);	  
        CoaL4 FindById(string l4Code);
        IEnumerable<CoaL4> GetL4Accounts();
    }
}
