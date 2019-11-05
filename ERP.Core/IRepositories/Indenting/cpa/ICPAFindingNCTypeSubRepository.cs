using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.cpa;

namespace ERP.Core.IRepositories.Indenting.cpa
{
    public interface ICPAFindingNCTypeSubRepository
    {
        void Add(CPAFindingNCTypeSub CPAFindingNCTypeSub);
        void Edit(CPAFindingNCTypeSub CPAFindingNCTypeSub);
        bool Remove(CPAFindingNCTypeSub CPAFindingNCTypeSub);
        CPAFindingNCTypeSub FindById(int CPAFindingNCTypeSubID);
        bool IsDuplicate(CPAFindingNCTypeSub CPAFindingNCTypeSub);
        IEnumerable<CPAFindingNCTypeSub> GetAllCPAFindingNCTypeSubs();
    }
}
