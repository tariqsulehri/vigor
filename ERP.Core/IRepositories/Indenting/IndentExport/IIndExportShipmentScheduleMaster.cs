using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.IndentExport;

namespace ERP.Core.IRepositories.Indenting.IndentExport
{
    public interface IIndExportShipmentScheduleRepository
    {
        void Add(IndExportShipmentScheduleMaster IndExportShipmentScheduleMaster);
        void Edit(IndExportShipmentScheduleMaster IndExportShipmentScheduleMaster);
        bool Remove(IndExportShipmentScheduleMaster IndExportShipmentScheduleMaster);
        IndExportShipmentScheduleMaster FindById(int id);
        //     bool IsDuplicate(IndExportInquiry indExportInquiry);
        IEnumerable<IndExportShipmentScheduleMaster> GetAllIndExportShipmentScheduleMaster();
    }
}
