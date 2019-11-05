using ERP.Core.Models.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.Inspection
{
    public interface IYarnInspectionReportTypeRepository
    {
        void Add(YarnInspectionReportType yarnInspectionReportType);
        void Edit(YarnInspectionReportType yarnInspectionReportType);
        bool Remove(YarnInspectionReportType yarnInspectionReportType);
        YarnInspectionReportType FindById(int id);
        bool IsDuplicate(YarnInspectionReportType yarnInspectionReportType);
        IEnumerable<YarnInspectionReportType> GetAllYarnInspectionReportTypes();

    }
}
