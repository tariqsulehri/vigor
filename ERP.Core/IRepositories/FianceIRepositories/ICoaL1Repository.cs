using System.Collections.Generic;
using ERP.Core.Models.Finance;

namespace ERP.Core.Repositories.FianceRepositiry

{
    public interface ICoaL1Repository
    {
        void Add(CoaL1 coaL1);
        void Edit(string l1Code);
        void Remove(string l1Code);
        CoaL1 FindById(string l1Code);
        IEnumerable<CoaL1> GetL1Accounts();
    }
}
