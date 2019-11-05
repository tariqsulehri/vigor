using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.InspExport
{
    public class FabricInspReportExport4PointDetails
    {
        [Key]
        [StringLength(8)]
        public string InspectionSerialNo { get; set; }

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

        public decimal? Points100SqYard { get; set; }

        public string FabricGrade { get; set; }

        public decimal? ActualWidth { get; set; }

        public int? Ends { get; set; }

        public int? Pick { get; set; }

        public decimal? NoOfCutFaults { get; set; }

        public int? MildWeftBar { get; set; }

        public int? SmallSlubsKnots { get; set; }

        public decimal? TotalPoints { get; set; }

        public decimal? WeightPerRoll { get; set; }

        public int? ActualGramSqr { get; set; }
    }
}
