using ERP.Core.Models.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.Inspection
{
    public interface IYarnInspectionUsterSettingRepository
    {
        void Add(YarnInspectionsUsterSetting yarnInspectionsUsterSetting);
        void Edit(YarnInspectionsUsterSetting yarnInspectionsUsterSetting);
        bool Remove(YarnInspectionsUsterSetting yarnInspectionsUsterSetting);
        YarnInspectionsUsterSetting FindById(int id);
        bool IsDuplicate(YarnInspectionsUsterSetting yarnInspectionsUsterSetting);
        IEnumerable<YarnInspectionsUsterSetting> GetAllYarnInspectionsUsterSetting();
    }
}
