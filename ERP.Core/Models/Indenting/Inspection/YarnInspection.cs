using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Core.Models.Party;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Core.Models.Indenting.Inspection
{
    public class YarnInspection
    {
        public YarnInspection()
        {
            this.YarnInspectionsUsterSetting = new HashSet<YarnInspectionsUsterSetting>();
            this.YarnInspectionAttachments = new HashSet<YarnInspectionAttachments>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(11)]
        public string InspectionSerialID { get; set; }

        public char InspReportType { get; set; }
        public char InspectionForMarket { get; set; }

        [ForeignKey("YarnInspectionReportType")]
        public int InspReportTypeId { get; set; }
        public virtual YarnInspectionReportType YarnInspectionReportType { get; set; }



        //[ForeignKey("YarnInspectionGrade")]
        public int YarnInsPectionGradeId { get; set; }
        //public virtual YarnInspectionGrade YarnInspectionGrade { get; set; }


        //[ForeignKey("IndDomesticDispatchSchedule")]
        public int ShipmentScheduleId { get; set; }
        //public virtual IndDomesticDispatchSchedule IndDomesticDispatchSchedule { get; set; }

        [ForeignKey("IndentDomestic")]
        public int IndentId { get; set; }
        public virtual IndDomestic IndentDomestic { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(10)]
        public string IndentKey { get; set; }

        [MaxLength(13)]
        public string SalesContractDetailID { get; set; }


        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(15)]
        public string RegisterNo { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InspectionDate { get; set; }

        public virtual ICollection<YarnInspectionsUsterSetting> YarnInspectionsUsterSetting { get; set; }
        public virtual ICollection<YarnInspectionAttachments> YarnInspectionAttachments { get; set; }

        public int CustomerId { get; set; }
        public string CustomerKey { get; set; }

        public int CustomerIDasSeller { get; set; }
        public string CustomerBuyerName { get; set; }
        public int CustomerIDasBuyer { get; set; }
        public string CustomerSellerName { get; set; }

        [ForeignKey("Product")]
        public int CommodityId { get; set; }
        public virtual Product Product { get; set; }


        [MaxLength(10)]
        public string MillUnit { get; set; }
        public string FCL { get; set; }

        [ForeignKey("QcInspector")]
        public int QcInspectorID { get; set; }
        public virtual QcInspector QcInspector { get; set; }

        public decimal AvgBagWeight { get; set; }


        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ProductionStartDate { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ProductionDate { get; set; }

        [MaxLength(20)]
        public string PConeColour { get; set; }
        public decimal tm { get; set; }
        public decimal CrPolyester { get; set; }
        public decimal CrCotton { get; set; }

        [MaxLength(15)]
        public string PolyFiber { get; set; }
        public decimal PolyDenier { get; set; }
        public decimal PolyLength { get; set; }

        [MaxLength(15)]
        public string PolyColour { get; set; }

        [MaxLength(25)]
        public string CottonArea { get; set; }

        [MaxLength(25)]
        public string CottonCountry { get; set; }
        public decimal CottonSlength { get; set; }
        public decimal CottonUr { get; set; }
        public decimal CottonFFi { get; set; }
        public decimal CottonStrength { get; set; }
        public decimal CottonMic { get; set; }
        public decimal CottonMicRange { get; set; }

        [MaxLength(15)]
        public string CottonGrade { get; set; }
        public decimal CottonLots { get; set; }

        [MaxLength(15)]
        public string CottonColour { get; set; }
        public decimal CottonTrash { get; set; }
        [StringLength(1)]
        public string ResultInputType { get; set; }
        public decimal RingActualCount { get; set; }
        public decimal RingCv { get; set; }
        public decimal RingStr { get; set; }
        public decimal RingCvStr { get; set; }
        public decimal RingClsp { get; set; }
        public decimal RingRkm { get; set; }
        public decimal RingU { get; set; }
        public decimal RingCvbOfU { get; set; }
        public decimal RingThin { get; set; }
        public decimal RingThick { get; set; }
        public decimal RingNeps { get; set; }
        public decimal RingIPI { get; set; }
        public decimal RingHairiness { get; set; }
        public decimal RingElongation { get; set; }
        public decimal ContainAutoConeResult { get; set; }
        public decimal AconeActualCount { get; set; }
        public decimal AconeCV { get; set; }
        public decimal AconeStr { get; set; }
        public decimal aconeCvStr { get; set; }
        public decimal AconeClsp { get; set; }
        public decimal AconeRkm { get; set; }
        public decimal AconeU { get; set; }
        public decimal AconeCvbOfU { get; set; }
        public decimal AconeThin { get; set; }
        public decimal AconeThick { get; set; }
        public decimal AconeNeps { get; set; }
        public decimal AconeIPI { get; set; }
        public decimal AconeHairiness { get; set; }
        public decimal AconeElongation { get; set; }
        public decimal PackedActualCount { get; set; }
        public decimal PackedCv { get; set; }
        public decimal PackedStr { get; set; }
        public decimal PackedCvStr { get; set; }
        public decimal PackedClsp { get; set; }
        public decimal PackedRkm { get; set; }
        public decimal PackedU { get; set; }
        public decimal PackedCvbOfU { get; set; }
        public decimal PackedThin { get; set; }
        public decimal PackedThick { get; set; }
        public decimal PackedNeps { get; set; }
        public decimal PackedIPI { get; set; }
        public decimal PackedHairiness { get; set; }
        public decimal PackedElongation { get; set; }

        [MaxLength(20)]
        public string Lotno { get; set; }

        [MaxLength(10)]
        public string Shade { get; set; }

        [MaxLength(10)]
        public string bstrips { get; set; }

        [MaxLength(10)]
        public string moisture { get; set; }

        [MaxLength(10)]
        public string yarnlength { get; set; }

        public string CompanyID { get; set; }


        public bool ContainAttachments { get; set; }


        public bool ContainDispatches { get; set; }

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


