using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting;

namespace ERP.Core.IRepositories.Indenting
{
    public interface IShipingLineRepository
    {
        void Add(ShipingLine shipingLine);
        void Edit(ShipingLine shipingLine);
        bool Remove(ShipingLine shipingLine);
        ShipingLine FindById(int id);

        bool IsDuplicate(ShipingLine shipingLine);
        IEnumerable<ShipingLine> GetAllShipingLine();
    }
}
