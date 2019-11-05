using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.cpa;

namespace ERP.Core.IRepositories.Indenting.cpa
{
    public interface ICpaFclRepository
    {
        void Add(CpaFcl CpaFcl);
        void Edit(CpaFcl CpaFcl);
        bool Remove(CpaFcl CpaFcl);
        CpaFcl FindById(string CpaFclNo);
        bool IsDuplicate(CpaFcl CpaFcl);
        IEnumerable<CpaFcl> GetAllCpaFcls();
    }
}
