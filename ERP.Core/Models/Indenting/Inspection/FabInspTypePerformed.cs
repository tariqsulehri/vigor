using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.InspExport;

namespace ERP.Core.Models.Indenting.Inspection
{
    public class FabInspTypePerformed
    {
        [Key]
        [StringLength(1)]
        public string InspTypePerformedID { get; set; }

        [Required]
        [StringLength(50)]
        public string InspTypePerformedDesc { get; set; }

        public virtual ICollection<FabricInspReportLocal> FabricInspReportLocal { get; set; }
        public virtual ICollection<FabricInspReportExport> FabricInspReportExport { get; set;}

    }
}
