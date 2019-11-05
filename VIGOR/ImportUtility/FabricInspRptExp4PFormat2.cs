namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FabricInspRptExp4PFormat2
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string InspectionSerialNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string SrNo { get; set; }

        public int? Rollno { get; set; }

        public int? NotedMeters { get; set; }

        public int? ActualMeters { get; set; }

        public int? CoarseYarn1 { get; set; }

        public int? SlackLooseWarp2 { get; set; }

        public int? BrokenWarp3 { get; set; }

        public int? Shortend4 { get; set; }

        public int? CoarseYarn5 { get; set; }

        public int? SlackLooseWarp6 { get; set; }

        public int? CoarseYarn7 { get; set; }

        public int? SlackLooseWarp8 { get; set; }

        public int? Coarseyarn9 { get; set; }

        public int? CockledYarn10 { get; set; }

        public int? ColorCont11 { get; set; }

        public int? coarseYarn12 { get; set; }

        public int? WeftCrackiness13 { get; set; }

        public int? StartingMarks14 { get; set; }

        public int? MissPick15 { get; set; }

        public int? DoublePick16 { get; set; }

        public int? CoarseYarn17 { get; set; }

        public int? MissPick18 { get; set; }

        public int? DoublePick19 { get; set; }

        public int? CoarseYarn20 { get; set; }

        public int? CoarseYarn21 { get; set; }

        public int? LongHair22 { get; set; }

        public int? ColorCont23 { get; set; }

        public int? ScorePerRollPiece { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AveragegPoint { get; set; }

        [StringLength(1)]
        public string FabricGrade { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Width { get; set; }
    }
}
