using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Party
{
    public class CustomerUnit
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(6)]
        public string mKey { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(50)]
        public string UnitTitle { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(100)]
        public string Details { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(30)]
        public string PersonEmail { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(20)]
        public string ContactPersonPhone { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [ForeignKey("FinParty")]
        public int PartyId { get; set; }
        public virtual FinParty FinParty { get; set; }

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
