using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting;

namespace ERP.Core.IRepositories.Indenting
{
    public interface IGoodsForwarderRepository
    {
        void Add(GoodsForwarder goodsForwarder);
        void Edit(GoodsForwarder goodsForwarder);
        bool Remove(GoodsForwarder goodsForwarder);
        GoodsForwarder FindById(int id);

        bool IsDuplicate(GoodsForwarder goodsForwarder);
        IEnumerable<GoodsForwarder> GetAllGoodsForwarder();
    }
}
