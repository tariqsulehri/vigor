using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class FNL_CommissionPaymentDetail
    {
        [StringLength(12)]
        public string FNLCommissionBillID { get; set; }

        [Key]
        [StringLength(12)]
        public string FNLCommission_invoice { get; set; }

        public decimal AmountReceived { get; set; }

        public decimal AmountAsBankCharges { get; set; }

        public decimal AmountAsMiscCharges { get; set; }

        public decimal NetAmountReceived { get; set; }

        public decimal AmountAsBankChargesLC { get; set; }

        public decimal AmountAsMiscChargesLC { get; set; }

        public decimal NetAmountReceivedLC { get; set; }

        public decimal AmountAsIncomeTax { get; set; }

        public decimal ReturnableCurrencyRate { get; set; }

        public int CurrencyId { get; set; }

        [StringLength(3)]
        public string ReturnableCurency_Key { get; set; }

        public decimal ReturnableAmountinFCafterDeductBCharges { get; set; }

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

    }
}
