using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.cpa
{
    public class CPAFindingNCTypeSub
    {
        [Key]
        public int CPAFindingNCTypeSubID { get; set; }


        [ForeignKey("CPAFindingNCType")]
        public int CPAFindingNCTypeID { get; set; }
        public virtual CPAFindingNCType CPAFindingNCType { get; set;}

        [StringLength(25)]
        public string DESCRIPTION { get; set; }
    }
}
