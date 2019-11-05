using ERP.Core.Models.Indenting.Inspection;
using System.Collections.Generic;

namespace ERP.Core.IRepositories.Indenting.Inspection
{
    public interface IFabricInspStatusRepository
    {
        void Add(FabricInspStatus fabricInspStatus);
        void Edit(FabricInspStatus fabricInspStatus);
        bool Remove(FabricInspStatus fabricInspStatus);
        FabricInspStatus FindById(int id);
        bool IsDuplicate(FabricInspStatus fabricInspStatus);
        IEnumerable<FabricInspStatus> GetAllFabricInspStatus();
    }
}
