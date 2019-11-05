using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.cpa
{
    public class CpaTypes
    {
//        public CpaType()
//        {
//            Cpas = new HashSet<Cpa>();
//        }

        [Key]
        [StringLength(1)]
        public string CpaType1 { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public virtual ICollection<Cpa> Cpas { get; set; }
    }
}
