using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentExport
{
    public class IndExportInquiryDetail
    {
        public int Id { get; set; }
        
        [ForeignKey("IndExportInquiry")]
        public int InquiryId { get; set; }
        public virtual IndExportInquiry IndExportInquiry { get; set; }

        [StringLength(16)]
        public string InquiryNoDetailIDRef { get; set; }
        [StringLength(16)]
        [Required(ErrorMessage = "Field is required....")]
        public string InquiryDetailNo { get; set; }
        [MaxLength(13)]
        [Required(ErrorMessage = "Field is required....")]
        public string InquiryKey { get; set; }

        [ForeignKey("Product")]
        [Required(ErrorMessage = "Field is required....")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        
        [Required(ErrorMessage = "Field is required....")]
        public decimal Quantity { get; set; }

        [ForeignKey("UnitOfSale")]
        [Required(ErrorMessage = "Field is required....")]
        public int UosId { get; set; }
        public virtual UnitOfSale UnitOfSale { get; set; }

        [MaxLength(150)]
        public string InquiryLineItemRemarks { get; set; }

        [StringLength(10)]
        public string SaleContractIssued{ get; set; }
        public char status { get; set; }

        [MaxLength(200)]
        public string SizeAndSpecification { get; set; }
        public bool isSampleRecevied { get; set; }
        public bool fabricDetail { get; set; }
        public bool packingDetail { get; set; }
        public bool trimDetail { get; set; }
        public bool colorPantoneCode { get; set; }
        public bool internalCosting { get; set; }

    }
}
