using ERP.Core.Models.Indenting.cpa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.cpa
{
    public interface ICpaNcTypeRepository
    {
        void Add(CpaNcType CpaNcType);
        void Edit(CpaNcType CpaNcType);
        bool Remove(CpaNcType CpaNcType);
        CpaNcType FindById(string CpaNcTypeNo);
        bool IsDuplicate(CpaNcType CpaNCType);
        IEnumerable<CpaNcType> GetAllCpaNCTypes();
    }
}
