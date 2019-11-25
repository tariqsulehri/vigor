using ERP.Core.Models.Indenting.Inspection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.cpa;
using ERP.Core.Models.Indenting.InspExport;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class IndDomesticDispatchSchedule
    {
        public int Id {get; set;}

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(13)]
        public string LocalDispatchNo { get; set; }

        public int srno { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(20)]
        public string BiltyNo { get; set;}

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime TransDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ContractedDeliveryDate { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(2)]
        public string TypeOfTransaction { get; set; }

        [ForeignKey("Product")]
        public int CommodityId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("IndentDomestic")]
        public int IndentId { get; set; }
        public virtual IndDomestic IndentDomestic { get; set; }


        //public virtual ICollection<YarnInspection> YarnInspections { get; set; }
        public virtual ICollection<IndentInspection> IndentInspections { get; set; }
        public virtual ICollection<CpaFcl> CpaFcls { get; set;}
        public virtual ICollection<KnittedFabricInspection> KnittedFabricInspections { get; set; }
        public virtual ICollection<FabricInspReportExport> FabricInspReportExport { get; set;}

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(13)]
        public string SalesContractDetail { get; set; }

        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(20)]
        public string VehicleNo { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        public bool IsReceivedStinv { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public decimal Quantity { get; set; }
        public decimal Balance { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [ForeignKey("GoodsForwarder")]
        public int GoodsFarwarderID { get; set; }
        public virtual GoodsForwarder GoodsForwarder { get; set; }


        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(255)]
        public string SalestaxInvoiceNo { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? SalestaxInvoiceDate { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(2)]
        public string IsDelayed { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(2)]
        public string DelayShipmentReason { get; set; }
                
        [MaxLength(250)]
        public string DelayShipmentReasonDescription { get; set; }

        [MaxLength(2)]
        public string IsComplaint { get; set; }

        [MaxLength(2)]
        public string isFirstDispatch { get; set; }

        [MaxLength(2)]
        public string IsReturn { get; set; }

        public bool isActive { get; set; }
        public bool isInvoiced { get; set; }

        public decimal GrossAmount { get; set; }
        public decimal GovtTaxes { get; set; }
        public decimal ReceivableAfterTaxes { get; set; }
        public decimal IncomeTaxPercent { get; set; }
        public decimal IncomeTaxAmount { get; set; }
        public decimal NetReceviable { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(200)]
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

    
	//[LeadTimeDescription] [char] (2) NULL,

