using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.Inspection
{
    public class KnittedFabricInspectionAttachment
    {
        public int id { get; set; }
        //[Key]
        //[StringLength(11)]
        //public string InspectionCode { get; set; }

        [ForeignKey("KnittedFabricInspection")]
        public string InspectionID { get; set; }
        public virtual KnittedFabricInspection KnittedFabricInspection { get; set; }

        [StringLength(150)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string FileDescription { get; set; }

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
