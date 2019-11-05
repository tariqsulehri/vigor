using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.InspExport;

namespace ERP.Core.IRepositories.Indenting.InspExport
{
    public interface IFabricInspReportExportRepository
    {
        void Add(FabricInspReportExport FabricInspReportExport);
        void Edit(FabricInspReportExport FabricInspReportExport);
        bool Remove(FabricInspReportExport FabricInspReportExport);
        FabricInspReportExport FindById(string ReportNo);
        bool IsDuplicate(FabricInspReportExport FabricInspReportExport);
        IEnumerable<FabricInspReportExport> GetAllFabricInspReportExport();
    }
}
