using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.IndentDomestic;

namespace ERP.Core.IRepositories.Indenting.IndentExport
{
    public interface IFNLCommissionBillRepository
    {
        void Add(FNLCommissionBill FNLCommissionBill);
        void Edit(FNLCommissionBill FNLCommissionBill);
        bool Remove(FNLCommissionBill FNLCommissionBill);
        FNLCommissionBill FindById(int id);

        bool IsDuplicate(FNLCommissionBill FNLCommissionBill);
        IEnumerable<FNLCommissionBill> GetAllFNLCommissionBills();

    }
}
