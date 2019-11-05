using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting
{
    public class IndDelayShipmentReason
    {
        public int Id { get; set; }

        [StringLength(2)]
        public string DelayShipmentReasonID { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(80)]
        public string Description { get; set; }

        [StringLength(2)]
        public string RefId { get; set; }

        [ForeignKey("IndDelayShipmentCategory")]
        public int DelayShipCategoryID { get; set; }
        public virtual IndDelayShipmentCategory IndDelayShipmentCategory { get; set;}

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
