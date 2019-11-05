using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class IndCommission
    {
        public int Id { get; set;}

        [Required(ErrorMessage = "This is required field...")]
        [MaxLength(13)]
        public string SaleContractCommID { get; set;}

        [ForeignKey("IndentDomestic")]
        public int IndentId { get; set; }
        public virtual IndDomestic IndentDomestic { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(10)]
        public string IndentKey { get; set; }

        [StringLength(6)]
        public string CustomerIdCommPaidTo_Ref { get; set; } //Vigor Ref.
        public int CustomerIdCommPaidTo   { get; set; }

        [StringLength(6)]
        public string CustomerIdCommPaidFrom_Ref { get; set; } //Vigor Ref.
        public int CustomerIdCommPaidFrom { get; set; }


        public decimal CommissionRate { get; set; }

        [Required(ErrorMessage = "This is required field...")]
        [MaxLength(1)]
        public string CommissionType { get; set; }
        public ICollection<CommInvoiceAgentComm> CommInvoiceAgentComm { get; set;}
        public bool IsinLocalCurrecncy { get; set;}
        public decimal CommissionValue { get; set; }

        [MaxLength(20)]
        public string Remarks { get; set;}
        public decimal CalculatedCommissionValue { get; set; }
	    public int CompanyId { get; set; }

        [StringLength(3)]
        public string CompanyId_Ref { get; set; } //Vigor Ref

        [MaxLength(500)]
        public string TTRoutingInstructions { get; set; }
        public bool IsPrintable { get; set; }
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
