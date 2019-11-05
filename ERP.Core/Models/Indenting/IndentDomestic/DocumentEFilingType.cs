using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class DocumentEFilingType
    {
        [Key]
        [StringLength(2)]
        public string DocumentID { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(2)]
        public string RefId { get; set; }

        [StringLength(1)]
        public string Scope { get; set; }

    }
}
