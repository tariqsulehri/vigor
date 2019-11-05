using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting
{
    public interface ICommodityTypeRepository
    {
        void Add(CommodityType commodityType);
        void Edit(CommodityType commodityType);
        bool Remove(CommodityType commodityType);
        CommodityType FindById(int id);
        bool IsDuplicate(CommodityType commodityType);
        IEnumerable<CommodityType> GetAllCommodityType();
    }
}
