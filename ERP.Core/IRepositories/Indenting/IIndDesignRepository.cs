using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting
{
    public interface IIndDesignRepository
    {
        void Add(IndDesign indDesign);
        void Edit(IndDesign indDesign);
        bool Remove(IndDesign indDesign);
        IndDesign FindById(int id);
        bool IsDuplicate(IndDesign indDesign);
        IEnumerable<IndDesign> GetAllIndDesigns();
    }
}
