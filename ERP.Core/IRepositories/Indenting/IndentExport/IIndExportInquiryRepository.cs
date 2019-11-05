using ERP.Core.Models.Indenting.IndentExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.IndentExport
{
    public interface IIndExportInquiryRepository
    {
       void Add(IndExportInquiry indExportInquiry);
       void Edit(IndExportInquiry indExportInquiry);
       bool Remove(IndExportInquiry indExportInquiry);
       IndExportInquiry FindById(int id);
   //     bool IsDuplicate(IndExportInquiry indExportInquiry);
       IEnumerable<IndExportInquiry> GetAllExportInquires();

    }
}
