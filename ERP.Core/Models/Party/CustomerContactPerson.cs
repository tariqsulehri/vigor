using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Common.Party;
using ERP.Core.Models.Party;

namespace ERP.Core.Models.Parties
{
    public class CustomerContactPerson
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(50)]
        public string Jobtitle { get; set; }

        [MaxLength(50)]
        public string ContactNumber { get; set; }

     
        [MaxLength(50)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Field is required....")]
        [ForeignKey("ContactType")]
        public int ContTypeId { get; set; }
        public virtual ContactType ContactType { get; set; }

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
