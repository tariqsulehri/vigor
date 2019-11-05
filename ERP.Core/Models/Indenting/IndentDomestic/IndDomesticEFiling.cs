using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class IndDomesticEFiling
    {
        [Key]
        [StringLength(10)]
        public string EfilingCode { get; set; }

        [StringLength(2)]
        public string DocumentType { get; set; }
        public int CompanyId { get; set; }

        [StringLength(3)]
        public string CompanyKey { get; set; }

        [ForeignKey("IndentDomestic")]
        public int IndentId { get; set; }
        public virtual IndDomestic IndentDomestic { get; set; }

        [StringLength(10)]
        public string IndentKey { get; set; }

        [ForeignKey("IndDomesticDispatchSchedule")]
        public int DispatchId { get; set; }
        public virtual IndDomesticDispatchSchedule IndDomesticDispatchSchedule { get; set; }

        [StringLength(13)]
        public string LocalDispatchKey { get; set; }

        [StringLength(50)]
        public string FileDescription { get; set; }

        [StringLength(30)]
        public string FileAttached { get; set; }

        [StringLength(1)]
        public string DocFileType { get; set; }

    }
}
