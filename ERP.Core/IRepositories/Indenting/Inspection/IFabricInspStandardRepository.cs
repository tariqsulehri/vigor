using ERP.Core.Models.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.Inspection
{
    public interface IFabricInspStandardRepository
    {
        void Add(FabricInspStandard fabricInspStandard);
        void Edit(FabricInspStandard FabricInspStandard);
        bool Remove(FabricInspStandard fabricInspStandard);
        FabricInspStandard FindById(int id);
        bool IsDuplicate(FabricInspStandard fabricInspStandard);
        IEnumerable<FabricInspStandard> GetAllfabricInspStandard();
    }
}
