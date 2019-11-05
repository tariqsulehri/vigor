using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.cpa
{
    public class CPAFindingNature
    {
        [Key]
        public int CPAFindingNatureID { get; set; }

        [Required]
        [StringLength(15)]
        public string CPAFindingNatureDesc{ get; set; }

    }
}
