using System.Collections.Generic;
using ERP.Core.Models.Finance;

namespace ERP.Core.Repositories.FianceRepositiry
{
    public interface ICoaL3Repository
    {
        void Add(CoaL3 coaL3);
        void Edit(string l3Code);
        void Remove(string l3Code);
        CoaL3 FindById(string l3Code);
        IEnumerable<CoaL3> GetL3Accounts();
    }
}
