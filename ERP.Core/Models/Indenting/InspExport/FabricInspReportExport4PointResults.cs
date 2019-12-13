using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.InspExport
{
    public class FabricInspReportExport4PointResults
    {
        [Key]
        [StringLength(8)]
        public string InspectionSerialNoID { get; set; }
        [StringLength(8)]
        [ForeignKey("FabricInspReportExport")]
        public string InspectionSerialNo { get; set; }
        public virtual FabricInspReportExport FabricInspReportExport { get; set; }
        [StringLength(25)]
        public string InspectionTypePerformed { get; set; }

        [StringLength(50)]
        public string Construction { get; set; }

        [StringLength(10)]
        public string Width { get; set; }

        [StringLength(1)]
        public string IC_quantitiesSubmitted { get; set; }

        [StringLength(1)]
        public string IC_Style { get; set; }

        [StringLength(1)]
        public string IC_Workmanship { get; set; }

        [StringLength(1)]
        public string IC_Packing { get; set; }

        [StringLength(1)]
        public string IC_Marking { get; set; }

        [StringLength(1)]
        public string IC_DataMeasurement { get; set; }

        [StringLength(1)]
        public string PC_Style { get; set; }

        [StringLength(1)]
        public string PC_Material { get; set; }

        [StringLength(1)]
        public string PC_Color { get; set; }

        [StringLength(1)]
        public string PC_Griege { get; set; }

        [StringLength(1)]
        public string ReferenceSample { get; set; }

        [StringLength(200)]
        public string PieceLengthCheck { get; set; }

        [StringLength(200)]
        public string PieceLength { get; set; }

        [StringLength(200)]
        public string RollsLengthCheck { get; set; }

        [StringLength(20)]
        public string SizeMeasurement { get; set; }

        [StringLength(1)]
        public string IndividualPacking { get; set; }

        [StringLength(1)]
        public string InnerPacking { get; set; }

        [StringLength(1)]
        public string ExportPacking { get; set; }

        [StringLength(200)]
        public string PackingAssortment { get; set; }

        [StringLength(1)]
        public string ML_BarCode { get; set; }

        [StringLength(1)]
        public string ML_ShippingMarks { get; set; }

        [StringLength(1)]
        public string ML_OtherMarks { get; set; }

        [StringLength(1)]
        public string ML_SideMark { get; set; }

        [StringLength(1)]
        public string ML_MainLabel { get; set; }

        [StringLength(1)]
        public string ML_Care { get; set; }

        [StringLength(1)]
        public string ML_Size { get; set; }

        [StringLength(1)]
        public string ML_Country { get; set; }

        [StringLength(1)]
        public string ML_HangTag { get; set; }

        [StringLength(1)]
        public string ML_PolyBag { get; set; }

        [StringLength(1)]
        public string ML_InnerBox { get; set; }

        [StringLength(1)]
        public string ML_OtherLabel { get; set; }

        [StringLength(200)]
        public string Lighting { get; set; }

        [StringLength(200)]
        public string LightingStatus { get; set; }

        [StringLength(200)]
        public string InspectionPlace { get; set; }

        [StringLength(200)]
        public string InspectionDoneOn { get; set; }

        [StringLength(200)]
        public string Cleanliness { get; set; }

        [StringLength(200)]
        public string WeatherCondition { get; set; }

    }
}
