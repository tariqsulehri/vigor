using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.cpa;

namespace ERP.Core.IRepositories.Indenting.cpa
{
    public interface ICPAFindingTypeRepository
    {
        void Add(CPAFindingType CPAFindingType);
        void Edit(CPAFindingType CPAFindingType);
        bool Remove(CPAFindingType CPAFindingType);
        CPAFindingType FindById(int CPAFindingID);
        bool IsDuplicate(CPAFindingType CPAFindingType);
        IEnumerable<CPAFindingType> GetAllCPAFindingTypes();
    }
}
