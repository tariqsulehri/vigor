using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Finance.GeneralVM
{
    public class VM_Vouchers
    {
            public int Id { get; set; }
            public string VKey { get; set; }
            public int VoucherNo { get; set; }
            public string FescalMonth { get; set; }
            public string Vtype { get; set; }
            public string VoucherDetail { get; set; }
        public string GlAccount { get; set; }
        public DateTime VoucherDate { get; set; }
            public decimal TotalDebit { get; set; }
            public decimal TotalCredit { get; set; }
            public decimal Debit { get; set; }
            public decimal Credit { get; set; }
            public string CheqNo { get; set; }
            public DateTime CreateDate { get; set; }
            public DateTime PostedDate { get; set; }
            public DateTime ModifiedOn { get; set; }
            public string Detail { get; set; }
            public Boolean isPosted { get; set; }
            public Boolean isEdited { get; set; }
            public Boolean isVerified { get; set; }
           // public string CreateUser { get; set; }
            //public string PostedUser { get; set; }
            //public string VerifyUser { get; set; }
            //public string ModifiedBy { get; set; }


        }

    }
