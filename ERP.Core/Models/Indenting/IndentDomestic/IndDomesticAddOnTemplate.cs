using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class IndDomesticAddOnTemplate
    {
        public int Id { get; set; }
        
        [ForeignKey("SalesTaxOffice")]
        public int TaxDeptId { get; set; }
        public virtual SalesTaxOffice SalesTaxOffice { get; set; }
        
        [Required(ErrorMessage = "Field is required....")]
        public UInt64 SerialNo { get; set; }

        [ForeignKey("IndDomesticPaymentsAddOnList")]
        public int AddOnId { get; set; }
        public virtual IndDomesticPaymentsAddOnList IndDomesticPaymentsAddOnList { get; set; }
        public decimal Amount { get; set;}
        public decimal TotalValue { get; set; }

        [MaxLength(2)]
        public string AddOnType  { get; set; }

        [MaxLength(2)]
        public string AddOnEffect { get; set; }

        [MaxLength(3)]
        public string DomesticPaymentAddonCalculatedOn { get; set;}

    }
}
