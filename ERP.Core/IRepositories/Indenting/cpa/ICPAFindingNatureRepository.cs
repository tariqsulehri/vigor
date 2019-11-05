using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.cpa;

namespace ERP.Core.IRepositories.Indenting.cpa
{
    public interface ICPAFindingNatureRepository
    {
        void Add(CPAFindingNature CPAFindingNature);
        void Edit(CPAFindingNature CPAFindingNature);
        bool Remove(CPAFindingNature CPAFindingNature);
        CPAFindingNature FindById(int CPAFindingNatureID);
        bool IsDuplicate(CPAFindingNature CPAFindingNature);
        IEnumerable<CPAFindingNature> GetAllCPAFindingNatures();

    }
}
