using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.InspExport;

namespace ERP.Core.Models.Indenting.Inspection
{
    public class FabricInspLoomType
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(50)]
        public string Description { get; set; }

        public ICollection<FabricInspReportLocal> FabricInspReportLocal { get; set; }
        public ICollection<FabricInspReportExport> FabricInspReportExport { get; set; }


    }
}
