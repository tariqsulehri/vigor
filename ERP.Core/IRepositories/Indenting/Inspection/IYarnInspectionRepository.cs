using ERP.Core.Models.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.Inspection
{
    public interface IYarnInspectionRepository
    {
        YarnInspection Add(YarnInspection yarnInspection);
        YarnInspection Edit(YarnInspection yarnInspection);
        bool Remove(YarnInspection yarnInspection);
        YarnInspection FindById(int id);
        // bool IsDuplicate(YarnInspection yarnInspection);
        IEnumerable<YarnInspection> GetAllYarnInspections();
    }
}
