using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.Inspection
{
    public class FabricInspReportLocalDetail
    {
        public int id { get; set;}

        [ForeignKey("FabricInspReportLocal")]
        public int FabInspReportId { get; set;}
        public virtual FabricInspReportLocal FabricInspReportLocal { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(10)]
        public string InspRepoSr { get; set; }

        public int RollOn { get; set; }
        public int NoteMeters { get; set; }
        public int ActualMeters { get; set; }
        public int SlubsKnotes { get; set; }
        public int PolyYarnRed { get; set; }
        public int PolyYarnBlue { get; set; }
        public int Holes { get; set; }
        public int MissPack1 { get; set; }
        public int MissPack2 { get; set; }
        public int MissPack3 { get; set; }
        public int MissPack4 { get; set; }
        public int ThickDoublePick { get; set; }
        public int ThickDoublePick2 { get; set; }
        public int ThickDoublePick3 { get; set; }
        public int ThickDoublePick4 { get; set; }
        public int WeftBar { get; set; }
        public int LooseEndsThickEnds1 { get; set; }
        public int LooseEndsThickEnds2 { get; set; }
        public int LooseEndsThickEnds3 { get; set; }
        public int LooseEndsThickEnds4 { get; set; }
        public int ReedMarkBrokenEndsWrap1 { get; set; }
        public int ReedMarkBrokenEndsWrap2 { get; set; }
        public int ReedMarkBrokenEndsWrap3 { get; set; }
        public int ReedMarkBrokenEndsWrap4 { get; set; }
        public int TotalPointsPerRoll { get; set; }
        public Decimal Points100SqYards { get; set; }
        
        [Required(ErrorMessage = "This isrequired Field")]
        public char FabricGrade { get; set; }
        public Decimal ActualWidth { get; set; }
        public int  Ends { get; set; }
        public int  Pick { get; set; }
        public Decimal  NoOfCutFault { get; set; }
        public int  MildWetBar { get; set; }
        public int  SmallslubKnotes { get; set; }
        public int  WeightPerRoll { get; set; }
        public int  ActualGramSqr { get; set; }


    }
}
