using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Parties;

namespace ERP.Core.Models.Common.Party
{
    public class SpecialInstruction
    {
        public int Id { get; set;}

        [Required(ErrorMessage = "This is Required field and Should be Unique....")]
        [MaxLength(100)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<CustomerInstruction> CustomerInstructions { get; set;} 

    }
}
