using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Core.Models.Party;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.Inspection
{
    public class FabricInspReportLocal
    {
        public FabricInspReportLocal()
        {
            this.FabricInspReportLocalDetails = new HashSet<FabricInspReportLocalDetail>();

        }
        public int Id { get; set; }

        [StringLength(8)]
        public string InspectionSerialNoID { get; set; } //Vigor Ref

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InspectionDate { get; set;}
        public ICollection<FabricInspReportLocalDetail> FabricInspReportLocalDetails { get; set;}
        public ICollection<FabInspReportLocalSum> FabInspReportLocalSum { get; set;}

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(10)]
        public string InspRepoSr { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(10)]
        public string InspRepoNo { get; set; }


        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(1)]
        public string ForMarket { get; set; }

        public int CompanyId { get; set; }

        [StringLength(3)]
        public string CompanyKey { get; set; }

        [ForeignKey("IndDomestic")]
        public int IndentId { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(10)]
        public string IndentKey { get; set; }

        public virtual IndDomestic IndDomestic { get; set; }

        [ForeignKey("FabricInspStandard")]
        public int FabInspStandardId { get; set; }
        public virtual FabricInspStandard FabricInspStandard { get; set; }

        [ForeignKey("FabricInspType")]
        public int FabInspTypeId { get; set; }
        public virtual FabricInspType FabricInspType { get; set; }

        [ForeignKey("FabricInspLoomType")]
        public int LoomTypeId { get; set; }
        public virtual FabricInspLoomType FabricInspLoomType { get; set; }

        [ForeignKey("FabricType")]
        public int FabricTypeId { get; set; }
        public virtual FabricType FabricType { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(1)]
        public string InspCalculationBasedOn { get; set; }

        [ForeignKey("FabricInspStatus")]
        public int InspStatusId { get; set; }
        public virtual FabricInspStatus FabricInspStatus { get; set; }


        [ForeignKey("QcInspector")]
        public int QcInspectorId { get; set; }
        public virtual QcInspector QcInspector { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        public decimal RollsInspected { get; set; }


        [Required(ErrorMessage = "This is Required field....")]
        public decimal BuyerAcceptancePoints { get; set; }

        public int bb_ends { get; set; }
        public int bb_picks { get; set; }
        public decimal bb_width { get; set; }
        public int bb_gsm { get; set; }



        public int ab_ends { get; set; }
        public decimal ab_picks { get; set; }
        public int ab_width { get; set; }
        public int ab_gsm { get; set; }


        [MaxLength(1000)]
        public string Remarks { get; set; }

        public int width { get; set; }
        public int QuantityInspected { get; set; }
        public int RollsAvailable { get; set; }

        public bool HeadBands{ get; set; }

        public bool ShadeVarivation { get; set; }

        public bool Stamped { get; set; }

        public bool ReadMarks { get; set; }

        public bool RubbingMarks { get; set; }

        public bool PolyYarn { get; set; }

        public bool Contination { get; set; }

        public bool Others { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime firstLine{ get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime secondLine { get; set; }

        public decimal TearingSWrap { get; set; }
        public decimal TearingSWeft { get; set; }
        public decimal Shirinkage { get; set; }
        public decimal PieceRatioLog { get; set; }
        public decimal PieceRatioShort { get; set; }
        public decimal PolyPropLine { get; set; }
        public decimal Cockled { get; set; }


        public bool BuyerSampleStatus { get; set; }

        public bool BuyerSampleDesign { get; set; }


        [MaxLength(20)]
        public string SelvedgeWeaves { get; set; }

        [MaxLength(20)]
        public string SelvedgeIdentify { get; set; }


        [MaxLength(20)]
        public string SelvedgeBindingWidth { get; set; }


        [MaxLength(20)]
        public string SelvedgeSize { get; set; }


        [MaxLength(50)]
        public string YarnSupplyWrap { get; set; }


        [MaxLength(50)]
        public string YarnSupplyWeft { get; set; }

        public Decimal TotalEnds { get; set; }
        public Decimal ReedCount { get; set; }
        public Decimal ReedSapce { get; set; }
        public Decimal EndsPerDent { get; set; }
        public Decimal PickInsertion { get; set; }



        public bool PickList { get; set; }

        public bool Marking { get; set; }

        public bool FaceMarking { get; set; }

        public bool PackingConditions { get; set; }

        [MaxLength(50)]
        public string WrapDirection { get; set; }

        public bool ShipmentSample { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(50)]
        public string Camdirection { get; set; }
        public int NumberOfLooms { get; set; }

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
