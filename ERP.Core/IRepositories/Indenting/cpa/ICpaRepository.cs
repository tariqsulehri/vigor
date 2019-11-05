using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.cpa;

namespace ERP.Core.IRepositories.Indenting.cpa
{
    public interface ICpaRepository
    {
        void Add(Cpa Cpa);
        void Edit(Cpa Cpa);
        bool Remove(Cpa Cpa);
        Cpa FindById(string CpaNo);
        bool IsDuplicate(Cpa Cpa);
        IEnumerable<Cpa> GetAllCpas();
    }
}
