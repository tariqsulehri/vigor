using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting
{
    public interface IIndSizeGroupRepository
    {
        void Add(IndSizeGroup indSizeGroup);
        void Edit(IndSizeGroup indSizeGroup);
        bool Remove(IndSizeGroup indSizeGroup);
        IndSizeGroup FindById(int id);
        bool IsDuplicate(IndSizeGroup indSizeGroup);
        IEnumerable<IndSizeGroup> GetAllIndSizeGroups();
    }
}
