using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.cpa
{
    public class CPAFindingType
    {
        [Key]
        public int CPAFindingID { get; set; }

        [Required]
        [StringLength(10)]
        public string CPAFindingType1 { get; set; }
    }
}
