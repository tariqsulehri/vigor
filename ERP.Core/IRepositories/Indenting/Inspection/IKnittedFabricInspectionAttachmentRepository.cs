using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.Inspection;

namespace ERP.Core.IRepositories.Indenting.Inspection
{
    public interface IKnittedFabricInspectionAttachmentRepository
    {
        void Add(KnittedFabricInspectionAttachment KnittedFabricInspectionAttachment);
        void Edit(KnittedFabricInspectionAttachment KnittedFabricInspectionAttachment);
        bool Remove(KnittedFabricInspectionAttachment KnittedFabricInspectionAttachment);
        KnittedFabricInspectionAttachment FindById(string id);
        bool IsDuplicate(KnittedFabricInspectionAttachment KnittedFabricInspectionAttachment);
        IEnumerable<KnittedFabricInspectionAttachment> GetAllKnittedFabricInspectionAttachments();
    }
}
