using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Core.Models.Common.Party;
using ERP.Core.Models.Parties;

namespace ERP.Core.Models.Party
{
    public class CustomerSocial
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(100)]
        public string Details { get; set; }
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [ForeignKey("Social")]
        public int Sid { get; set; }
        public virtual Social Social { get; set; }

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
