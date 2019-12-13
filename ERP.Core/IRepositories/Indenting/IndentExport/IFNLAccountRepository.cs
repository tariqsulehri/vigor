using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.IndentDomestic;

namespace ERP.Core.IRepositories.Indenting.IndentExport
{
    public interface IFNLAccountRepository
    {
        void Add(FNLAccount FNLAccount);
        void Edit(FNLAccount FNLAccount);
        bool Remove(FNLAccount FNLAccount);
        FNLAccount FindById(int id);
        bool IsDuplicate(FNLAccount FNLAccount);
        IEnumerable<FNLAccount> GetAllFNLAccounts();
    }
}
