using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR
{
    public class HR_GazzettedDays
    {
        [Key]
        [StringLength(6)]
        public string GazzettedDateId { get; set; }

        public DateTime? GazzettedDateFrom { get; set; }

        public DateTime? GazzettedDateTo { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        [StringLength(4)]
        public string TranYear { get; set; }

        [StringLength(3)]
        public string Company { get; set; }

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
