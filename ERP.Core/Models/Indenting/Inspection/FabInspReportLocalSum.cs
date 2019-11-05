using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.Inspection
{
    public class FabInspReportLocalSum
    {
        public int id { get; set; }

        [ForeignKey("FabricInspReportLocal")]
        public int FabInspReportId { get; set; }
        public virtual FabricInspReportLocal FabricInspReportLocal { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(10)]
        public string InspRepoSr { get; set; }

        public int SlubsKnotes { get; set;}
        public int PolyYarn { get; set;}
        public int Holes { get; set;}
        public int MissPick { get; set;}
        public int ThickDoublePick { get; set;}
        public int WeftBar { get; set;}
        public int LooseEndsThickEnds { get; set;}
        public int ReedMarksBrokenWraps { get; set;}
        public int ThiinPlaces { get; set;}
        public int TotalPointsPerRoll { get; set;}
        public Decimal PointsPer100Sqy { get; set;}
        public Decimal TPointsPer100Sqy { get; set;}
        public Decimal PointsPer100M { get; set;}

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
