using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.cpa
{
    public class CpaNcType
    {
        //        public CpaNcType()
        //        {
        //           Cpa Cpa = new HashSet<Cpa>();
        //        }

        [Key]
        [StringLength(1)]
        public string CPaNcType1 { get; set; }

        [Required]
        [StringLength(150)]
        public string CpaNcName { get; set; }

        public int? CPAFindingID { get; set; }

        public int? CPAFindingNatureID { get; set; }

        public int? CPAFindingNCTypeID { get; set; }

        public int? CPAFindingNCTypeSubID { get; set; }

        [StringLength(1)]
        public string isCustomerComplaint { get; set; }

        public virtual ICollection<Cpa> Cpas { get; set; }

    }
}
