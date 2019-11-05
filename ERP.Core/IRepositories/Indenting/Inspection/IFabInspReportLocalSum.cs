using ERP.Core.Models.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.Inspection
{
    public interface IFabInspReportLocalSum
    {
        void Add(FabInspReportLocalSum fabInspReportLocalSum);
        void Edit(FabInspReportLocalSum fabInspReportLocalSum);
        bool Remove(FabInspReportLocalSum fabInspReportLocalSum);
        FabInspReportLocalSum FindById(int id);
        bool IsDuplicate(FabInspReportLocalSum fabInspReportLocalSum);
        IEnumerable<FabInspReportLocalSum> GetAllFabInspReportLocalSum();
    }
}
