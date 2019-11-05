using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Finance;

namespace ERP.Core.IRepositories.FinanceIRepositories
{
    public interface IFinVoucherRepository
    {
        void Add(FinVoucher finVoucher, List<FinVoucherDetail> lst);
        void Edit(FinVoucher finvoucher , string VKey, List<FinVoucherDetail> lst);
		 void PostorUnpost(FinVoucher existingVoucher);											  
        void Remove(string vKey);
        string GetVoucherKey(FinVoucher voucher, string key);
		 FinVoucher GetVoucherKey(FinVoucher finVoucher);												
        FinVoucher GetFinVoucherByKey(string vKey);
        IEnumerable<FinVoucher> GetAllFinVouchers(string voucherType);
        IEnumerable<FinVoucher> GetAllFinVouchers();
IEnumerable<FinLedger> GetAllFinLedger();
    }
}
