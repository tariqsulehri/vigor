using ERP.Core.Models.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.FinanceIRepositories
{
   public interface IFinBookTypeRepositry
    {
        void Add(FinBookType finBook);
        void Edit(FinBookType finBook);
        bool Remove(int BookID);
        bool IsDuplicate(FinBookType finBook);
        CoaL1 FindById(int BookID);
        IEnumerable<FinBookType> GetAllbBookTypes();
    }
}
