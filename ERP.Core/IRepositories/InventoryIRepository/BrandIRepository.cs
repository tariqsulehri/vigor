using System.Collections.Generic;
using ERP.Core.Models.Common;
using ERP.Core.Models.Inventory;

namespace ERP.Core.IRepositories.InventoryIRepository
{
    public interface IBrandRepository
    {
        void Add(Brand brand);
        void Edit(Brand brand);
        bool Remove(int id);
        Brand FindById(int id);

        bool IsDuplicate(Brand brand);
        IEnumerable<Brand> GetAllbrands();
    }
}
