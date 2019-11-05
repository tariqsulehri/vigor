using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.Inspection;

namespace ERP.Core.IRepositories.Indenting.Inspection
{
    public interface IKnittedFabricInspBleachedRepository
    {
        void Add(KnittedFabricInspBleached KnittedFabricInspBleached);
        void Edit(KnittedFabricInspBleached KnittedFabricInspBleached);
        bool Remove(KnittedFabricInspBleached KnittedFabricInspBleached);
        KnittedFabricInspBleached FindById(string id);
        bool IsDuplicate(KnittedFabricInspBleached KnittedFabricInspBleached);
        IEnumerable<KnittedFabricInspBleached> GetAllKnittedFabricInspBleacheds();
    }
}
