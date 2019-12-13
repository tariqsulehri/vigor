using ERP.Core.Models.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentExport
{
    public class IndExportLCDetail
    {
        [Key]
        [StringLength(12)]
        public string LcSerialNo { get; set; }
        public int CompanyId { get; set; }
        
        [ForeignKey("IndentDomestic")]
        public int IndentId { get; set; }
        public virtual IndDomestic IndentDomestic { get; set; }

        [Required]
        [StringLength(10)]
        public string SalesContractKey { get; set; }

        [Required]
        [StringLength(20)]
        public string LcNo { get; set; }

        public DateTime LcDate { get; set; }

        public DateTime? LastShipmentDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LcAmount { get; set; }

        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

        public bool IsCommissionDeducted { get; set; }

        public int CreatedBy { get; set; }
        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        public int ModifiedBy { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ModifiedOn { get; set; }
    }
}
