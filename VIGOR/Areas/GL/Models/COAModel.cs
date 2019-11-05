using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VIGOR.Areas.GL.Models
{
    public class COAModel
    {
        [StringLength(2, MinimumLength = 2)]
        public string L1Code { get; set; }

        [Required(ErrorMessage = "You must enter title of particular account....")]
        [MaxLength(30)]
        public string L1Title { get; set; }
        [StringLength(5, MinimumLength = 5)]
        public string L2Code { get; set; }

        [Required(ErrorMessage = "You must enter title of particular account....")]
        [MaxLength(30)]
        public string L2Title { get; set; }

        [StringLength(9, MinimumLength = 9)]
        public string L3Code { get; set; }

        [Required(ErrorMessage = "You must enter title of particular account....")]
        [MaxLength(30)]
        public string L3Title { get; set; }

        [StringLength(13, MinimumLength = 13)]
        public string L4Code { get; set; }

        [Required(ErrorMessage = "You must enter title of particular account....")]
        [MaxLength(30)]
        public string L4Title { get; set; }
        [StringLength(18, MinimumLength = 18)]
        public string L5Code { get; set; }

        [Required(ErrorMessage = "You must enter title of particular account....")]
        [MaxLength(30)]
        public string L5Title { get; set; }

        [Required(ErrorMessage = "You must define account type ....")]
        [StringLength(2, MinimumLength = 2)]
        public string Type { get; set; }
        public string CO { get; set; }
        public Boolean Active { get; set; }
        public string BookType { get; set; }
        public Boolean IsDept { get; set; }
        public Boolean IsLoc { get; set; }
        public Boolean IsEmp { get; set; }
        public Boolean IsCust { get; set; }
        public char leveltype { get; set; }
    }
}