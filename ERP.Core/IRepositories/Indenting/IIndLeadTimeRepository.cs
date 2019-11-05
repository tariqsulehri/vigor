using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting
{
    public interface IIndLeadTimeRepository
    {
        void Add(IndLeadTime indLeadTime);
        void Edit(IndLeadTime indLeadTime);
        bool Remove(IndLeadTime indLeadTime);
        IndLeadTime FindById(int id);
        bool IsDuplicate(IndLeadTime indLeadTime);
        IEnumerable<IndLeadTime> GetAllIndLeadTime();
    }
}
