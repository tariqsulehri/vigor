using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.Inspection
{
    public class YarnInspectionsUsterSetting
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(2)]
        public string UsterResultTypeId { get; set; }
        public decimal value { get; set;}


        [ForeignKey("YarnInspection")]
        public int YarnInspectionId { get; set; }
        public virtual YarnInspection YarnInspection { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(11)]
        public string InspectionSerialID { get; set; }

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
