using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.cpa;

namespace ERP.Core.IRepositories.Indenting.cpa
{
    public interface ICpaTypesRepository
    {
        void Add(CpaTypes CpaTypes);
        void Edit(CpaTypes CpaTypes);
        bool Remove(CpaTypes CpaTypes);
        CpaTypes FindById(string CpaTypesNo);
        bool IsDuplicate(CpaTypes CpaTypes);
        IEnumerable<CpaTypes> GetAllCpaTypes();
    }
}
