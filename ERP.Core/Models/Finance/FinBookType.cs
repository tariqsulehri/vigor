using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Finance
{
  public  class FinBookType
    {[Key]
        public int BookID { get; set; }
        [Required(ErrorMessage = "Required field...")]
        [StringLength(60)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Required field...")]
        [StringLength(1)]
        public string BookType { get; set; }
    }
}
