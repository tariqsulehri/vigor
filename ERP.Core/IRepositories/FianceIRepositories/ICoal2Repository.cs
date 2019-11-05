using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Finance;

namespace ERP.Core.Repositories.FianceRepositiry
{
    public interface ICoaL2Repository
    {
        void Add(CoaL2 coaL2);
        void Edit(string l2Code);
        void Remove(string l2Code);
        CoaL2 FindById(string l2Code);
        IEnumerable<CoaL2> GetL2Accounts();
    }
}
