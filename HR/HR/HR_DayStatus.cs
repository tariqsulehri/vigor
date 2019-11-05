using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR
{
    public class HR_DayStatus
    {
        [Key]
        public long DayStatusID { get; set; }

        [StringLength(9)]
        [Required(ErrorMessage = "Field is required....")]
        public string Description { get; set; }

        [StringLength(1)]
        [Required(ErrorMessage = "Field is required....")]
        public string Abbreviation { get; set; }
        public decimal WorkingDays { get; set; }
        public decimal DeductDays { get; set; }
        public bool AllowedInAttendance { get; set; }
        public DateTime isActive { get; set; }
        public decimal CountAs { get; set; }
        public Boolean ListedAsLeave { get; set; }

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
