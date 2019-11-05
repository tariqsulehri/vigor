using ERP.Core.Models.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.Inspection
{
    public interface IFabricInspReportLocalRepository
    {
        void Add(FabricInspReportLocal fabricInspReportLocal);
        void Edit(FabricInspReportLocal fabricInspReportLocal);
        bool Remove(FabricInspReportLocal fabricInspReportLocal);
        FabricInspReportLocal FindById(int id);
        bool IsDuplicate(FabricInspReportLocal fabricInspReportLocal);
        IEnumerable<FabricInspReportLocal> GetAllFabricInspReportLocal();
    }
}
