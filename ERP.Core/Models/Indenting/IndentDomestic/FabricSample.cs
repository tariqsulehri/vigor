using ERP.Core.Models.Party;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class FabricSample
    {
        public int Id { get; set; }

        [ForeignKey("IndentDomestic")]
        public int IndentId { get; set; }
        public virtual IndDomestic IndentDomestic { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(10)]
        public string IndentKey { get; set; }

        [MaxLength(13)]
        public string SalesContractDetailID { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SampleReceiveDate { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        public double quantity { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SpecSheetOn { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(20)]
        public string StorageNo { get; set; }

        [ForeignKey("Product")]
        public int CommodityId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("QcInspector")]
        public int CheckedByID { get; set; }
        public virtual QcInspector QcInspector { get; set; }
        
        [ForeignKey("FinParty")]
        public int CustomerId { get; set; }
        public virtual FinParty FinParty { get; set; }

        public bool tally { get; set; }


        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(250)]
        public string Remarks { get; set; }


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
