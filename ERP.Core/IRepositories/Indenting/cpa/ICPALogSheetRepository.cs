using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.cpa;

namespace ERP.Core.IRepositories.Indenting.cpa
{
    public interface ICPALogSheetRepository
    {
        void Add(CPALogSheet CPALogSheet);
        void Edit(CPALogSheet CPALogSheet);
        bool Remove(CPALogSheet CPALogSheet);
        CPALogSheet FindById(int id);
        bool IsDuplicate(CPALogSheet CPALogSheet);
        IEnumerable<CPALogSheet> GetAllCPALogSheets();
    }
}
