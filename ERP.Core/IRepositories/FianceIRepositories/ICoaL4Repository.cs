using System.Collections.Generic;
using ERP.Core.Models.Finance;

namespace ERP.Core.Repositories.FianceRepositiry
{
    public interface ICoaL4Repository
    {
        void Add(CoaL4 coaL4);
        void Edit(string l4Code);
        void Remove(string l4Code);
        CoaL4 FindById(string l4Code);
        IEnumerable<CoaL4> GetL4Accounts();
    }
}
