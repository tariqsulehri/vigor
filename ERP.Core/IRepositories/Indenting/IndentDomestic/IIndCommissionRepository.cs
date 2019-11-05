using ERP.Core.Models.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.IndentDomestic
{
    public interface IIndCommissionRepository
    {
        void Add(IndCommission indCommission);
        void Edit(IndCommission indCommission);
        bool Remove(IndCommission indCommission);
        IndCommission FindById(int id);
        bool IsDuplicate(IndCommission indCommission);
        IEnumerable<IndCommission> GetAllIndIndCommission();
    }
}
