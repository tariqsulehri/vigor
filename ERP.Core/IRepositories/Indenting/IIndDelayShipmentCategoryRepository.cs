using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting
{
    public interface IIndDelayShipmentCategoryRepository
    {
        void Add(IndDelayShipmentCategory indDelayShipmentCategory);
        void Edit(IndDelayShipmentCategory indDelayShipmentCategory);
        bool Remove(IndDelayShipmentCategory indDelayShipmentCategory);
        IndDelayShipmentCategory FindById(int id);
        bool IsDuplicate(IndDelayShipmentCategory indDelayShipmentCategory);
        IEnumerable<IndDelayShipmentCategory> GetAllIndDelayShipmentCategorys();
    }
}
