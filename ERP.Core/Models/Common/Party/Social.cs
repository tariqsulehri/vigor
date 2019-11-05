using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Parties;
using ERP.Core.Models.Party;

namespace ERP.Core.Models.Common.Party
{
    public class Social
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This is Required field and Should be Unique....")]
        [MaxLength(30)]
        public string Detail { get; set; }
        public ICollection<CustomerSocial> CustomerrSocials { get; set;}
    }
}
