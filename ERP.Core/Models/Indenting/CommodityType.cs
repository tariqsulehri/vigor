using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Core.Models.Indenting.IndentExport;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting
{
    public class CommodityType
    {
        public int Id { get; set; }

        [StringLength(2)]
        public string RefId { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(50)]
        public string Description { get; set; }

        
        [MaxLength(1)]
        public string ScheduleType { get; set; }

        [MaxLength(1)]
        public string DomesticMarket { get; set; }

        [MaxLength(1)]
        public string ScheduleTypeDomestic { get; set; }

        [MaxLength(1)]
        public string InternationalMarket { get; set; }

        [MaxLength(1)]
        public string ScheduleTypeInternational { get; set; }

        public ICollection<DeptDealsInCommodityType> DeptDealsInCommodityType { get; set;}

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
        public ICollection<Product> Products { get; set; }
        public ICollection<IndDomesticInquiry> IndDomesticInquiries { get; set; }
        public ICollection<IndExportInquiry> IndExportInquiry { get; set; }
        public ICollection<QcInspector> QcInspectors { get; set; }

      }
}
