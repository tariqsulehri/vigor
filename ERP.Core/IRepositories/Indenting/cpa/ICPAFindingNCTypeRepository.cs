using ERP.Core.Models.Indenting.cpa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.cpa
{
    public interface ICPAFindingNCTypeRepository
    {
        void Add(CPAFindingNCType ICPAFindingNCType);
        void Edit(CPAFindingNCType ICPAFindingNCType);
        bool Remove(CPAFindingNCType ICPAFindingNCType);
        CPAFindingNCType FindById(int CPAFindingNCTypeID);
        bool IsDuplicate(CPAFindingNCType CPAFindingNCType);
        IEnumerable<CPAFindingNCType> GetAllCPAFindingNCTypes();
    }
}
