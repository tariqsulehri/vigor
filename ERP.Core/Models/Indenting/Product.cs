using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Core.Models.Indenting.IndentExport;
using ERP.Core.Models.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(6)]
        public string RefId { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(250)]
        public string Description { get; set; }

        [MaxLength(1)]
        public string isValueAdded { get; set; }

        public Decimal StuffedQty { get; set; }

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

        [ForeignKey("CommodityType")]
        public int CommodityId { get; set; }
        public virtual CommodityType CommodityType { get; set; }
        public virtual ICollection<IndExportInquiryDetail> IndExportInquiryDetail { get; set; }
        public virtual ICollection<IndDomesticInquiryDetail> IndDomesticInquiryDetails { get; set; }
        public virtual ICollection<IndDomesticDispatchSchedule> IndDomesticDispatchSchedule { get; set; }
        public virtual ICollection<YarnInspection> YarnInspections { get; set; }
        public virtual ICollection<FabricSample> FabricSample { get; set; }
        public virtual ICollection<IndDomesticPaymentAddOn> IndDomesticPayment { get; set; }


    }
}
