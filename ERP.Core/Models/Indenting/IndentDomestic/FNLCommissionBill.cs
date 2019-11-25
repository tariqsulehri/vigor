using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class FNLCommissionBill
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(12)]
        public string FNLCommissionBillKey { get; set; }

        public DateTime BillDate { get; set; }
        
        [StringLength(18, MinimumLength = 18)]
        public string FNLAccount { get; set; }  // this will Gl Account

        public bool? IsPostedBySystem { get; set; }

        public bool? IsOpeningBalance { get; set; }
        
        [Required]
        public int CompanyId { get; set; }
        
        [StringLength(3)]
        public string CompanyId_Key { get; set; }

        public int CurrencyId { get; set; }
        [StringLength(3)]
        public string Currency { get; set; }

        [StringLength(3)]
        public string TranType { get; set; }

        public int DeptId { get; set;}

        [StringLength(4)]
        public string DepartmentID_Key { get; set; }


        public int CommissionInvoiceNo { get; set;}

        [StringLength(10)]
        public string CommissionInvoiceNo_Key { get; set; }

        public decimal CommissionAmount { get; set; }

        public decimal ClearedAmount { get; set; }
        public DateTime? ClearedAmountReceiveDate { get; set; }

        public bool? IsCleared { get; set; }

        [StringLength(6)]
        public string Responsibility { get; set; }

        public decimal AmountCredited { get; set; }

        public decimal AmountAsCharges { get; set; }

        public decimal AmountAsMiscCharges { get; set; }

        public int exchangeRate_ID { get; set;}
        public decimal? ExchangeRate { get; set; }

        public decimal? TaxDeductedPercent { get; set; }

        public decimal? AccountAsTaxDeducted { get; set; }

        public decimal? AccountAsReceivedinBankAccount { get; set; }

        [StringLength(250)]
        public string Narration { get; set; }
        public decimal? ReturnableCurrencyRate { get; set; }
        
        public int ReturnableCurrencyId { get; set; }

        [StringLength(3)]
        public string ReturnableCurency_Key { get; set; }

        public decimal? ReturnableFCAmount { get; set; }

        [StringLength(1)]
        public string RequirePosting { get; set; }

        [StringLength(1)]
        public string PaymentPosted { get; set; }

        [StringLength(50)]
        public string SenderRefNo { get; set; }

        public DateTime? SenderRefNoDate { get; set; }


        public int CreatedBy { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ModifiedOn { get; set; }
        
        public virtual ICollection<FNL_CommissionPaymentDetail> FNL_CommissionPaymentDetails { get; set;}
        
    }
}
