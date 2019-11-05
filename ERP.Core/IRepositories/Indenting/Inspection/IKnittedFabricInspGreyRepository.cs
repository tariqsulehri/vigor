using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.Inspection;

namespace ERP.Core.IRepositories.Indenting.Inspection
{
    public interface IKnittedFabricInspGreyRepository
    {
        void Add(KnittedFabricInspGrey KnittedFabricInspGrey);
        void Edit(KnittedFabricInspGrey KnittedFabricInspGrey);
        bool Remove(KnittedFabricInspGrey KnittedFabricInspGrey);
        KnittedFabricInspGrey FindById(string id);
        bool IsDuplicate(KnittedFabricInspGrey KnittedFabricInspGrey);
        IEnumerable<KnittedFabricInspGrey> GetAllKnittedFabricInspGreys();

    }
}
