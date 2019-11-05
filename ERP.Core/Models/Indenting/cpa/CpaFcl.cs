using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.IndentDomestic;

namespace ERP.Core.Models.Indenting.cpa
{
    public class CpaFcl
    {
        [Key]
        [StringLength(8)]
        public string CPaNo { get; set; }

        [ForeignKey("IndDomesticDispatchSchedule")]
        public int ShipmentScheduleid { get; set; }
        public virtual IndDomesticDispatchSchedule IndDomesticDispatchSchedule { get; set; }

        [Required]
        [MaxLength(13)]
        public string ShipmentScheduleidKey { get; set; }

    }
}
