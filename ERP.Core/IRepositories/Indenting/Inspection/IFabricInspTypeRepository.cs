using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.Inspection
{
    public interface IFabricInspTypeRepository
    {
        void Add(FabricInspType fabricInspType);
        void Edit(FabricInspType fabricInspType);
        bool Remove(FabricInspType fabricInspType);
        FabricInspType FindById(int id);
        bool IsDuplicate(FabricInspType fabricInspType);
        IEnumerable<FabricInspType> GetAllFabricInspTypes();
    }
}
