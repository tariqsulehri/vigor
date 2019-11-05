using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class IndDomesticInquiryDetail
    {
        public int Id { get; set; }

        //[ForeignKey("IndDomestic")]
        //public int IndentId { get; set; }
        //public virtual IndDomestic IndDomestic { get; set; }

        //[Required(ErrorMessage = "Field is required....")]
        //[MaxLength(10)]
        //public string IndentKey { get; set; }

        [ForeignKey("IndDomesticInquiry")]
        public int InquiryId { get; set; }
        public virtual IndDomesticInquiry IndDomesticInquiry { get; set; }

        [MaxLength(13)]
        [Required(ErrorMessage = "Field is required....")]
        public string InquiryKey { get; set; }

        [ForeignKey("Product")]
        [Required(ErrorMessage = "Field is required....")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [MaxLength(13)]
        public string NewCommodity { get; set; }

//        [MaxLength(100)]
  //      public string WalkInCustomer { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        public decimal Quantity { get; set; }
        
        [ForeignKey("UnitOfSale")]
        [Required(ErrorMessage = "Field is required....")]
        public int UosId { get; set; }
        public virtual UnitOfSale UnitOfSale { get; set; }

    }
}
