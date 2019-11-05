using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Core.Models.Parties;
using ERP.Core.Models.Party;

namespace ERP.Core.Models.Common.Party
{
    public class Certifications
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This is Required field and Should be Unique....")]
        [MaxLength(100)]
        public string CertificationName { get; set; }

        [StringLength(4)]
        public string RefId { get; set; }
        public bool IsActive { get; set;}
        public ICollection<CustomerCertification> CustomerCertifications { get; set; }

    }
}
