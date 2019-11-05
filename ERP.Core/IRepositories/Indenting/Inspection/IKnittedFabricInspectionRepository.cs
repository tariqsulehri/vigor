using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.Inspection;

namespace ERP.Core.IRepositories.Indenting.Inspection
{
    public interface IKnittedFabricInspectionRepository
    {
        void Add(KnittedFabricInspection KnittedFabricInspection);
        void Edit(KnittedFabricInspection KnittedFabricInspection);
        bool Remove(KnittedFabricInspection KnittedFabricInspection);
        KnittedFabricInspection FindById(string id);
        bool IsDuplicate(KnittedFabricInspection KnittedFabricInspection);
        IEnumerable<KnittedFabricInspection> GetAllKnittedFabricInspections();
    }
}
