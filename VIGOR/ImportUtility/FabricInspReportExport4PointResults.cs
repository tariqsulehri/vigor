namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FabricInspReportExport4PointResults
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string InspectionSerialNoID { get; set; }

        [StringLength(25)]
        public string InspectionTypePerformed { get; set; }

        [StringLength(50)]
        public string Construction { get; set; }

        [StringLength(10)]
        public string Width { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1)]
        public string IC_quantitiesSubmitted { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1)]
        public string IC_Style { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(1)]
        public string IC_Workmanship { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(1)]
        public string IC_Packing { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(1)]
        public string IC_Marking { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(1)]
        public string IC_DataMeasurement { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(1)]
        public string PC_Style { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(1)]
        public string PC_Material { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(1)]
        public string PC_Color { get; set; }

        [StringLength(1)]
        public string PC_Griege { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(1)]
        public string ReferenceSample { get; set; }

        [StringLength(200)]
        public string PieceLengthCheck { get; set; }

        [StringLength(200)]
        public string PieceLength { get; set; }

        [StringLength(200)]
        public string RollsLengthCheck { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(20)]
        public string SizeMeasurement { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(1)]
        public string IndividualPacking { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(1)]
        public string InnerPacking { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(1)]
        public string ExportPacking { get; set; }

        [StringLength(200)]
        public string PackingAssortment { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(1)]
        public string ML_BarCode { get; set; }

        [Key]
        [Column(Order = 16)]
        [StringLength(1)]
        public string ML_ShippingMarks { get; set; }

        [Key]
        [Column(Order = 17)]
        [StringLength(1)]
        public string ML_OtherMarks { get; set; }

        [Key]
        [Column(Order = 18)]
        [StringLength(1)]
        public string ML_SideMark { get; set; }

        [Key]
        [Column(Order = 19)]
        [StringLength(1)]
        public string ML_MainLabel { get; set; }

        [Key]
        [Column(Order = 20)]
        [StringLength(1)]
        public string ML_Care { get; set; }

        [Key]
        [Column(Order = 21)]
        [StringLength(1)]
        public string ML_Size { get; set; }

        [Key]
        [Column(Order = 22)]
        [StringLength(1)]
        public string ML_Country { get; set; }

        [Key]
        [Column(Order = 23)]
        [StringLength(1)]
        public string ML_HangTag { get; set; }

        [Key]
        [Column(Order = 24)]
        [StringLength(1)]
        public string ML_PolyBag { get; set; }

        [Key]
        [Column(Order = 25)]
        [StringLength(1)]
        public string ML_InnerBox { get; set; }

        [Key]
        [Column(Order = 26)]
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
