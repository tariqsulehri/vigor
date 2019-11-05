using ERP.Core.Models.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.Inspection
{
    public interface IFabricInspLoomTypeRepository
    {
        void Add(FabricInspLoomType fabricInspLoomType);
        void Edit(FabricInspLoomType fabricInspLoomType);
        bool Remove(FabricInspLoomType fabricInspLoomType);
        FabricInspLoomType FindById(int id);
        bool IsDuplicate(FabricInspLoomType fabricInspLoomType);
        IEnumerable<FabricInspLoomType> GetAllFabricInspLoomType();
    }
}
