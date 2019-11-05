using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting
{
    public class ExchangeRates
    {

        public int Id { get; set; }

        [StringLength(3)]
        public string RefId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ExRDate  { get; set; }

        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

        public Decimal SellingRate { get; set; }
        public Decimal BuyingRate { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(10)]
        public string Rate120Selling{ get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(10)]
        public string Rate120Buying { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(10)]
        public string OpenMktSelling { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(10)]
        public string OpenMktBuying { get; set; }


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
