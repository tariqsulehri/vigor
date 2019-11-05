using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Core.Models.Inventory;
using ERP.Core.Models.Parties;

namespace ERP.Core.Models.Party
{
    public class CustomerBrand
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }

        //[Required(ErrorMessage = "Field is required....")]
        //[ForeignKey("Brand")]
        //public int Bid { get; set; }
        //public virtual Brand Brand { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(6)]
        public string mKey { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(50)]
        public string BrandName { get; set; }

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
