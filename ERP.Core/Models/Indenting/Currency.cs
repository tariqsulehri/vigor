using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting;
using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Core.Models.Indenting.IndentExport;

namespace ERP.Core.Models.Indenting
{
    public class Currency
    {
        public int Id { get; set; }

        [StringLength(3)]
        public string RefId { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(50)]
        public string Description { get; set; }

        [MaxLength(5)]
        public string Symbol { get; set; }

        public ICollection<ExchangeRates> ExchangeRates { get; set; }
        public ICollection<IndCommissionInvoice> IndCommissionInvoice { get; set; }
        //public ICollection<IndDomesticInquiry> IndDomesticInquiry { get; set; }
        public ICollection<IndExportInquiry> IndExportInquiry { get; set; }


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
