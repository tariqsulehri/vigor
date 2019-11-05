using ERP.Core.Models.Party;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class CommInvoiceAgentComm
    {
        public int Id { get; set; }
        
        [ForeignKey("IndCommissionInvoice")]
        public int CommissionInvoiceNo { get; set; }
        public virtual IndCommissionInvoice IndCommissionInvoice { get; set; }

        [Required(ErrorMessage = "This is required field...")]
        [MaxLength(13)]
        public string CommissionInvoiceNoKey { get; set; }
        [Required(ErrorMessage = "This is required field...")]

        [ForeignKey("IndentDomestic")]
        public int IndentId { get; set; }
        public virtual IndDomestic IndentDomestic { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(10)]
        public string IndentKey { get; set; }

        [Required(ErrorMessage = "This is required field...")]
        [StringLength(13)]
        public string SaleContractCommID { get; set; }
        //public string SalesContractCommCode { get; set; }
        public int CompanyId { get; set; }

        [StringLength(3)]
        public string Company { get; set; } //Vigor Reference

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(10)]
        public string CommissionInvoiceKey { get; set; }

        [ForeignKey("IndCommission")]
        public int CommissionId { get; set; }
        public virtual IndCommission IndCommission { get; set; }

        [StringLength(6)]
        public string CustomerIDCommPaidTo_Ref { get; set; }
        public int CommPaidTo { get; set; }

        [StringLength(6)]
        public string CustomerIDCommPaidFrom_Ref { get; set; }
        public int CommPaidFrom { get; set; }
        public decimal CommissionRate { get; set; }
        public Boolean isLocalCurrency { get; set; }

        [Required(ErrorMessage = "This is required field...")]
        [MaxLength(1)]
        public string CommissionType { get; set; }
        public decimal CommissionValue { get; set; }
        public decimal CommissionDiscountValue { get; set; }
        public decimal SalesTaxValue { get; set; }
        public decimal CommissionNetValue { get; set; }

        [Required(ErrorMessage = "This is required field...")]
        [MaxLength(100)]
        public string CommissionDiscountRemarks { get; set; }
        public int ModifiedBy { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ModifiedOn { get; set; }

    }
}
