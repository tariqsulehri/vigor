using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting
{
    public interface IIndSizeRepository
    {
        void Add(IndSize indSize);
        void Edit(IndSize indSize);
        bool Remove(IndSize indSize);
        IndSize FindById(int id);
        bool IsDuplicate(IndSize indSize);
        IEnumerable<IndSize> GetAllIndSizes();
    }
}
