using ERP.Core.Models.Indenting;
using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Core.Models.Indenting.IndentExport;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting
{
    public class UnitOfSale
    {

        public int Id { get; set; }

        [StringLength(3)]
        public string RefId { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        [ForeignKey("IndUnitOfMeasure")]
        [Required(ErrorMessage = "Field is required....")]
        public int UomID { get; set; }
        public virtual IndUnitOfMeasure IndUnitOfMeasure { get; set; }

        [ForeignKey("UnitOfRate")]
        [Required(ErrorMessage = "Field is required....")]
        public int UorID { get; set; }
        public virtual UnitOfRate UnitOfRate { get; set; }

        [MaxLength(2)]
        public string StuffingUnit { get; set; }

        public decimal Factor { get; set; }
        public int StandardUOM { get; set; }
        public decimal StandardUOMFactor { get; set; }

        [MaxLength(200)]
        public string Remarks { get; set; }
        [MaxLength(1)]
        public string ShipmentSchedule { get; set; }

        [MaxLength(1)]
        public string RequireStuffing { get; set; }
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

        public ICollection<IndDomesticInquiryDetail> IndDomesticInquiryDetail { get; set; }
        public ICollection<IndExportInquiryDetail> IndExportInquiryDetail { get; set; }
        public ICollection<IndCommissionInvoiceDetail> IndCommissionInvoiceDetail { get; set; }


    }
}
