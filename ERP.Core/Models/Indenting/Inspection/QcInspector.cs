using ERP.Core.Models.Indenting.IndentDomestic;
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
    public class QcInspector
    {
        public int Id { get; set; }

        [StringLength(4)]
        public string RefId { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(50)]
        public string FullName { get; set; }
        public bool isActive { get; set; }

        [ForeignKey("CommodityType")]
        public int CommodityId { get; set; }
        public virtual CommodityType CommodityType { get; set; }

        public virtual ICollection<FabricInspReportLocal> FabricInspReportLocal { get; set;}
        public virtual ICollection<YarnInspection> YarnInspections { get; set;}
        public virtual ICollection<FabricSample> FabricSample { get; set;}

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
