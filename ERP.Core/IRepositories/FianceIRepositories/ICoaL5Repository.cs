using System.Collections.Generic;
using ERP.Core.Models.Finance;

namespace ERP.Core.IRepositories.FianceIRepositories
{
    public interface ICoaL5Repository
    {
        void Add(CoaL5 coaL5);
        void Edit(string l5Code);
        void Remove(string l5Code);
        CoaL5 FindById(string l5Code);
        IEnumerable<CoaL5> GetL5Accounts();
    }
}
