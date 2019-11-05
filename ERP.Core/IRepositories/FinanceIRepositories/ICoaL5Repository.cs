using System.Collections.Generic;
using ERP.Core.Models.Finance;

namespace ERP.Core.IRepositories.FinanceIRepositories
{
    public interface ICoaL5Repository
    {
        void Add(CoaL5 coaL5);
        void Edit(CoaL5 l5Code);
        bool Remove(string l5Code);
		 bool IsDuplicate(CoaL5 coaL5);							  
        CoaL5 FindById(string l5Code);
        IEnumerable<CoaL5> GetL5Accounts();
    }
}
