using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class IndDomesticPaymentAddOn
    {
        public int Id { get; set; }

        [StringLength(2)]
        public string RefId { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(13)]
        public string TransactionNo { get; set; }
        
        [Required(ErrorMessage = "Field is required....")]
        public int SerialNumber { get; set; }


        [Required(ErrorMessage = "Field is required....")]
        [ForeignKey("IndDomesticPaymentsAddOnList")]
        public int domPaymentAddOnListId { get; set; }
        public virtual IndDomesticPaymentsAddOnList IndDomesticPaymentsAddOnList { get; set; }
        
        [Required(ErrorMessage = "Field is required....")]
        [ForeignKey("IndDomesticDispatchSchedule")]
        public int LocalDispatchNo { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(13)]
        public string LocalDispatchKey { get; set; }
        public virtual IndDomesticDispatchSchedule IndDomesticDispatchSchedule { get; set;}

        [Required(ErrorMessage = "Field is required....")]
        public decimal Quantity { get; set;}

        [Required(ErrorMessage = "Field is required....")]
        public decimal Amount { get; set; }
        public decimal NetReceviable { get; set; }
        public decimal TaxPercent { get; set; }
        public decimal TaxAmount { get; set; }
        
        [ForeignKey("Product")]
        [Required(ErrorMessage = "Field is required....")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(2)]
        public string AddOnType { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(2)]
        public string AddOnEffect { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(2)]

        public string DomesticPaymentAddonCalculatedOn { get; set; }
       

    }
}
