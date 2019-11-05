using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Core.Models.Parties;

namespace ERP.Core.Models.Common
{
    public class Country
    {
        public int Id { get; set; }

        [StringLength(4)]
        public string RefId { get; set; }

        [Required(ErrorMessage = "Country name is required field..." )]
        [StringLength(30)]
        public string Name   { get; set; }

        [Required(ErrorMessage = "Country code is required field...")]
        [StringLength(4), MinLength(4)]
        public string Ccode { get; set; }

        [ForeignKey("Region")]
        public int RCode { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<State> States { get; set; }
        //public virtual ICollection<Company> Companies { get; set; }

        //public virtual ICollection<FinParty> FinParties { get; set; }
    }

    
}
