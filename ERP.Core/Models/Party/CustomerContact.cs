using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Core.Models.Common.Party;
using ERP.Core.Models.Parties;

namespace ERP.Core.Models.Party
{
    public class CustomerContact
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string ContactNumber { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [ForeignKey("FinParty")]
        public int PartyId { get; set;}
        public virtual FinParty FinParty { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [ForeignKey("ContactType")]
        public int ContTypeId { get; set; }
        public virtual ContactType ContactType { get; set; }

    }
}
