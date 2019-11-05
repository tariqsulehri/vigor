using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.Inspection;

namespace ERP.Core.IRepositories.Indenting.Inspection
{
    public interface IKnittedFabricInspDyedRepository
    {
        void Add(KnittedFabricInspDyed KnittedFabricInspDyed);
        void Edit(KnittedFabricInspDyed KnittedFabricInspDyed);
        bool Remove(KnittedFabricInspDyed KnittedFabricInspDyed);
        KnittedFabricInspDyed FindById(string id);
        bool IsDuplicate(KnittedFabricInspDyed KnittedFabricInspDyed);
        IEnumerable<KnittedFabricInspDyed> GetAllKnittedFabricInspDyeds();
    }
}
