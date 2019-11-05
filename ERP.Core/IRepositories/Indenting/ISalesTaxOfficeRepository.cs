
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting;

namespace ERP.Core.IRepositories.Indenting
{
    public interface ISalesTaxOfficeRepository
    {
        void Add(SalesTaxOffice salesTaxOffice);
        void Edit(SalesTaxOffice salesTaxOffice);
        bool Remove(SalesTaxOffice salesTaxOffice);
        SalesTaxOffice FindById(int id);
        bool IsDuplicate(SalesTaxOffice salesTaxOffice);
        IEnumerable<SalesTaxOffice> GetAllSalesTaxOffices();

    }
}
