using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.cpa
{
    public class CPAFindingNCType
    {
        [Key]
        public int CPAFindingNCTypeID { get; set; }

        [Required]
        [StringLength(25)]
        public string CPAFindingNCTypeDesc { get; set; }

        public virtual ICollection<CPAFindingNCTypeSub> CPAFindingNCTypeSubs { get; set;}
    }
}
