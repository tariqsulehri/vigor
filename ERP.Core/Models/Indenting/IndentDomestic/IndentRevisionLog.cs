using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class IndentRevisionLog
    {
        public int id { get; set;} 
        public DateTime LogDate { get; set; }

        [ForeignKey("IndentDomestic")]
        public int IndentId { get; set; }
        public virtual IndDomestic IndentDomestic { get; set; }

        [StringLength(10)]
        public string IndentKey { get; set; }
        public DateTime EditStart { get; set; }
        public DateTime Editend { get; set; }

        [StringLength(500)]
        public string RevisedReason { get; set; }

        public int RevisedByUserId { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ModifiedOn { get; set; }
    }
}
