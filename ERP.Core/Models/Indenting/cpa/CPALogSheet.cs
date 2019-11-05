using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.cpa
{
    public class CPALogSheet
    {
        [Key]
        public int id { get; set;}

        [ForeignKey("Cpa")]
        [StringLength(8)]
        public string CpaNo { get; set; }
        public virtual Cpa Cpa { get; set;}
        [StringLength(250)]
        public string Remarks { get; set; }

        public DateTime Dated { get; set; }
    }
}
