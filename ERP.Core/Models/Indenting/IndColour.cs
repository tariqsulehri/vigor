using ERP.Core.Models.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting
{
    public class IndColour
    {
        public int Id { get; set; }

        [StringLength(5)]
        public string RefId { get; set; } // Vigor Ref.

        [Required(ErrorMessage = "This is Required Field")]
        public double CodeId { get; set; }

        [Required(ErrorMessage = "This is Required Field")]
        public double ColourId { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "This is Required Field")]
        public string ColourDescription { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        //public ICollection<IndDomesticDetail> IndDemosticDetail { get; set;}

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
