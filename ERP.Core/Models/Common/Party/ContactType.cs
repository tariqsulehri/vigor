using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ERP.Core.Models.Party;

namespace ERP.Core.Models.Common.Party
{
    public class ContactType
    {
        public int Id { get; set; }

        [StringLength(2)]
        public string RefId { get; set; }

        [Required(ErrorMessage = "This is Required field and Should be Unique....")]
        [MaxLength(30)]
        public string Title { get; set; }
        public ICollection<CustomerContact> CustomerContacts { get; set;}

    }
}
