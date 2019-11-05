using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class IndDomesticPaymentsAddOnList
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(3)]
        public string AddOnId { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(50)]
        public string AddOnDescription { get; set; }
        public ICollection<IndDomesticPaymentAddOn> IndDomesticPaymentAddOns { get; set; }
    }
}
