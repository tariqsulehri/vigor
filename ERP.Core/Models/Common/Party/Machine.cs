using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Core.Models.Party;

namespace ERP.Core.Models.Common.Party
{
    public class Machine
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "This is Required field and Should be Unique....")]
        [MaxLength(100)]

        public string Name { get; set; }
        public string Details { get; set; }
        public bool IsActive { get; set; }

      //  public ICollection<CustomerMachine> CustomerMachines { get; set; }


    }
}
