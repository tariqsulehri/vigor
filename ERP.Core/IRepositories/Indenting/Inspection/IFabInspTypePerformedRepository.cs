using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.Inspection;

namespace ERP.Core.IRepositories.Indenting.Inspection
{
    public interface IFabInspTypePerformedRepository
    {
        void Add(FabInspTypePerformed FabInspTypePerformed);
        void Edit(FabInspTypePerformed FabInspTypePerformed);
        bool Remove(FabInspTypePerformed FabInspTypePerformed);
        FabInspTypePerformed FindById(string id);
        bool IsDuplicate(FabInspTypePerformed FabInspTypePerformed);
        IEnumerable<FabInspTypePerformed> GetAllFabInspTypePerformed();
    }
}
