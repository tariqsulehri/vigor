using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class IndCommissionInvoice
    {
        public IndCommissionInvoice()
        {
            this.IndCommissionDetail=new HashSet<IndCommissionInvoiceDetail>();
            this.CommInvoiceAgentComm=new HashSet<CommInvoiceAgentComm>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "This is required field...")]
        [MaxLength(10)]
        public string CommissionInvoiceKey { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; }

        [ForeignKey("IndentDomestic")]
        public int IndentId { get; set; }
        public virtual IndDomestic IndentDomestic { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(10)]
        public string IndentKey { get; set; }

        [StringLength(3)]
        public string company { get; set; }

        [StringLength(13)]
        public string ShipmentScheduleShipmentNo { get; set; }


        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(250)]
        public string SuppliorInvoiceNo { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime SuppliorInvoiceDate { get; set; }

        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal InvoiceTotal { get; set; }
        public decimal InvoiceDiscount { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(200)]
        public string Signature { get; set; }
        public bool IsPosted { get; set; }
        public bool IsncludeSalesTax { get; set; }
        public bool IsWithHoldTax { get; set; }
        public decimal SalesTaxRate { get; set; }
        
        [ForeignKey("SalesTaxOffice")]
        public int TaxOfficeId { get; set;}
        public virtual SalesTaxOffice SalesTaxOffice { get; set;}

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DispatchIncludeFrom { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DispatchIncludeTo { get; set; }
        
        public ICollection<IndCommissionInvoiceDetail> IndCommissionDetail { get; set;}
        public ICollection<CommInvoiceAgentComm> CommInvoiceAgentComm { get; set; }

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

        public int PostedBy { get; set; }
        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime PostedOn { get; set; }

      

    }
}
