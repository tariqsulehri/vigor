using ERP.Core.Models.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.Inspection
{
    public interface IFabricTypeRepository
    {
        void Add(FabricType fabricType);
        void Edit(FabricType fabricType);
        bool Remove(FabricType fabricType);
        FabricType FindById(int id);
        bool IsDuplicate(FabricType fabricType);
        IEnumerable<FabricType> GetAllFabricTypes();
    }
}
