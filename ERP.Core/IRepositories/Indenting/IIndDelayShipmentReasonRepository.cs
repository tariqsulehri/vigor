using ERP.Core.Models.Indenting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting
{
    public interface IIndDelayShipmentReasonRepository
    {
        void Add(IndDelayShipmentReason indDelayShipmentReason);
        void Edit(IndDelayShipmentReason indDelayShipmentReason);
        bool Remove(IndDelayShipmentReason indDelayShipmentReason);
        IndDelayShipmentReason FindById(int id);
        bool IsDuplicate(IndDelayShipmentReason indDelayShipmentReason);
        IEnumerable<IndDelayShipmentReason> GetAllIndDelayShipmentReasons();
    }
}
