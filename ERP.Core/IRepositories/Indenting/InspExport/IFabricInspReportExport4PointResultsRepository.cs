using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.InspExport;

namespace ERP.Core.IRepositories.Indenting.InspExport
{
    public interface IFabricInspReportExport4PointResultsRepository
    {
        void Add(FabricInspReportExport4PointResults FabricInspReportExport4PointResults);
        void Edit(FabricInspReportExport4PointResults FabricInspReportExport4PointResults);
        bool Remove(FabricInspReportExport4PointResults FabricInspReportExport4PointResults);
        FabricInspReportExport4PointResults FindById(string ResultsNo);
        bool IsDuplicate(FabricInspReportExport4PointResults FabricInspReportExport4PointResults);
        IEnumerable<FabricInspReportExport4PointResults> GetAllFabricInspReportExport4PointResults();
    }
}
