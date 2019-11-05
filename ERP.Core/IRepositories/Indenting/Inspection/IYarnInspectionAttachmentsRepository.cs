using ERP.Core.Models.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.Inspection
{
    public interface IYarnInspectionAttachmentsRepository
    {
        void Add(YarnInspectionAttachments yarnInspectionAttachments);
        void Edit(YarnInspectionAttachments yarnInspectionAttachments);
        bool Remove(YarnInspectionAttachments yarnInspectionAttachments);
        YarnInspectionAttachments FindById(int id);
        bool IsDuplicate(YarnInspectionAttachments yarnInspectionAttachments);
        IEnumerable<YarnInspectionAttachments> GetAllYarnInspectionAttachments();
    }
}
