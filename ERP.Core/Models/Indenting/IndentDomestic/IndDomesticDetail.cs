using ERP.Core.Models.Indenting;
using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Core.Models.Party;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Indenting.Inspection;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class IndDomesticDetail
    {
        public int Id { get; set; }

        [MaxLength(13)]
        public string SalesContractDetailID { get; set; }

        [ForeignKey("IndentDomestic")]
        public int IndentId { get; set; }  
        public virtual IndDomestic IndentDomestic { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(10)]
        public string IndentKey { get; set; }


        [ForeignKey("Product")]
        public int CommodityId { get; set; }
        public virtual Product Product { get; set; }

        [MaxLength(200)]
        public string CommoditySpecification { get; set; }

        [ForeignKey("UnitOfSale")]
        [Required(ErrorMessage = "Field is required....")]
        public int UosID { get; set; }
        public virtual UnitOfSale UnitOfSale { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal CommRate { get; set; }
        public decimal Stuffing { get; set; }

        //[ForeignKey("IndSize")]
         public int SizeCode { get; set; }
         //public virtual IndSize IndSize { get; set; }

        [MaxLength(500)]
        public string SizeSpecifications { get; set; }
        public decimal GSM { get; set; }
        public decimal PerPieceWeight { get; set; }
        public decimal PerPieceUnitWeight { get; set; }

        [MaxLength(500)]
        public string LabDip { get; set; }

        [MaxLength(5)]
        public string LabDipOption { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime LabDipDate { get; set; }

        public decimal WeightDispatched { get; set; }

        public string TypeColor { get; set; }

        [MaxLength(30)]
        public string FabricWidth { get; set; }

        public decimal QuantityReq { get; set; }
        public decimal UnitQuantityReq { get; set; }

        [MaxLength(20)]
        public string BarCode { get; set; }
        public decimal TotalValue { get; set; }

        public decimal TotalValueOnCommRate { get; set; }

        public decimal ExecutedQuantity { get; set; }
        public decimal ExecutedValue { get; set; }
        public decimal QuantityPerFCL { get; set; }

        //[ForeignKey("IndColour")]
        public int ColourId { get; set; }
        //public virtual IndColour IndColour { get; set; }

        public int SuppliorCode { get; set; }   //Party Code

       // [ForeignKey("IndDesign")]
        public int DesignId { get; set; }
      //  public virtual IndDesign IndDesign {get; set;}

        [MaxLength(30)]
        public string DesignNo { get; set;}

        public virtual ICollection<KnittedFabricInspection> KnittedFabricInspections { get; set; }

    }
}


    


 
	