namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FabricInspReportExport4PointDetails
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string InspectionSerialNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string SrNo { get; set; }

        public int? RollNo { get; set; }

        public int? NotedMeters { get; set; }

        public int? ActualMeters { get; set; }

        public int? SlubsKnots { get; set; }

        public int? PolyYarnRed { get; set; }

        public int? PolyYarnRed1 { get; set; }

        public int? PolyYarnRed2 { get; set; }

        public int? PolyYarnRed3 { get; set; }

        public int? PolyYarnBlue { get; set; }

        public int? PolyYarnBlue1 { get; set; }

        public int? PolyYarnBlue2 { get; set; }

        public int? PolyYarnBlue3 { get; set; }

        public int? Holes { get; set; }

        public int? MissPack1 { get; set; }

        public int? MissPack2 { get; set; }

        public int? MissPack3 { get; set; }

        public int? MissPack4 { get; set; }

        public int? ThickDoublePick { get; set; }

        public int? ThickDoublePick2 { get; set; }

        public int? ThickDoublePick3 { get; set; }

        public int? ThickDoublePick4 { get; set; }

        public int? WeftBar { get; set; }

        public int? LooseEndsThickEnds1 { get; set; }

        public int? LooseEndsThickEnds2 { get; set; }

        public int? LooseEndsThickEnds3 { get; set; }

        public int? LooseEndsThickEnds4 { get; set; }

        public int? ReedMarkBrokenWrap1 { get; set; }

        public int? ReedMarkBrokenWrap2 { get; set; }

        public int? ReedMarkBrokenWrap3 { get; set; }

        public int? ReedMarkBrokenWrap4 { get; set; }

        public int? ThinPlaces { get; set; }

        public int? TotalPointsPerRoll { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Points100SqYard { get; set; }

        [StringLength(2)]
        public string FabricGrade { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ActualWidth { get; set; }

        public int? Ends { get; set; }

        public int? Pick { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? NoOfCutFaults { get; set; }

        public int? MildWeftBar { get; set; }

        public int? SmallSlubsKnots { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TotalPoints { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? WeightPerRoll { get; set; }

        public int? ActualGramSqr { get; set; }
    }
}
