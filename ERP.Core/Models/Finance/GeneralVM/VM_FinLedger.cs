using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Finance.GeneralVM
{
    public class VM_FinLedger
    {

        public int Id { get; set; }
        public string l1Code { get; set; }
        public string l1_Title { get; set; }

        public string l2Code { get; set; }
        public string l2_Title { get; set; }

        public string l3Code { get; set; }
        public string l3_Title { get; set; }

        public string l4Code { get; set; }
        public string l4_Title { get; set; }

        public string l5Code { get; set; }
        public string l5_Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string VKey { get; set; }
        public virtual FinVoucher FinVoucher { get; set; }
        public string GlCode { get; set; }
        public virtual CoaL5 CoaL5 { get; set; }
        public string Detail { get; set; }
        public DateTime ChequeDate { get; set; }
        public DateTime ClearingDate { get; set; }
        public string ChequeNo { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public int UserId { get; set; }
    }
}
