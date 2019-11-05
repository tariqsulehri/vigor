using ERP.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting
{
    public interface IMarkeetDealsInRepository
    {
        void Add(MarkeetDealsIn markeetDealsIn);
        void Edit(MarkeetDealsIn markeetDealsIn);
        bool Remove(MarkeetDealsIn markeetDealsIn);
        bool IsDuplicate(MarkeetDealsIn markeetDealsIn);
        IEnumerable<MarkeetDealsIn> GetAllMarkeetDealsIn();
        MarkeetDealsIn GetAllMarkeetDealsInById(int id);

    }
}
