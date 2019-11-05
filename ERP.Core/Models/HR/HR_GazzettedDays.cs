using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Common;

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

        //------------------------
        [ForeignKey("Company")]
        [Required]
        public int companyID { get; set; }
        public virtual Company Company { get; set; }

        [StringLength(3)]
        [Required(ErrorMessage = "Field is required....")]
        public string CompanyKey { get; set; }
        //-----------------

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
