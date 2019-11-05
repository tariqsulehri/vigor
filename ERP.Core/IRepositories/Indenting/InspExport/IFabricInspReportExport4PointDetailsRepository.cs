using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.InspExport;

namespace ERP.Core.IRepositories.Indenting.InspExport
{
    public interface IFabricInspReportExport4PointDetailsRepository
    {
        void Add(FabricInspReportExport4PointDetails FabricInspReportExport4PointDetails);
        void Edit(FabricInspReportExport4PointDetails FabricInspReportExport4PointDetails);
        bool Remove(FabricInspReportExport4PointDetails FabricInspReportExport4PointDetails);
        FabricInspReportExport4PointDetails FindById(string RointsNo);
        bool IsDuplicate(FabricInspReportExport4PointDetails FabricInspReportExport4PointDetails);
        IEnumerable<FabricInspReportExport4PointDetails> GetAllFabricInspReportExport4PointDetails();
    }
}
