using ERP.Core.Models.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Indenting.IndentDomestic
{
    public interface IIndCommissionInvoiceRepository
    {
        void Add(IndCommissionInvoice indCommissionInvoice);
        void Edit(IndCommissionInvoice indCommissionInvoice);
        bool Remove(IndCommissionInvoice indCommissionInvoice);
        IndCommissionInvoice FindById(int id);
        bool IsDuplicate(IndCommissionInvoice indCommissionInvoice);
        IEnumerable<IndCommissionInvoice> GetAllIndIndCommissionInvoice();
    }
}
