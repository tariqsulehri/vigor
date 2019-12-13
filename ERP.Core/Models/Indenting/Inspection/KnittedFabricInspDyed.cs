using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.Inspection
{
    public class KnittedFabricInspDyed
    {
        //[Key]
        //[StringLength(9)]
        //public string InspectionCode { get; set; }

        public int id { get; set; }

        [ForeignKey("KnittedFabricInspection")]
        public string InspectionID { get; set; }
        public virtual KnittedFabricInspection KnittedFabricInspection { get; set; }

        [StringLength(30)]
        public string ShadeColour { get; set; }

        [StringLength(30)]
        public string Type { get; set; }

        [StringLength(30)]
        public string Length { get; set; }

        [StringLength(30)]
        public string Width { get; set; }

        [StringLength(30)]
        public string Gsm { get; set; }

        [StringLength(30)]
        public string Guage { get; set; }

        [StringLength(30)]
        public string DIA { get; set; }

        [StringLength(50)]
        public string Evenness { get; set; }

        [StringLength(30)]
        public string Dyability { get; set; }

        [StringLength(30)]
        public string Barre { get; set; }

        [StringLength(30)]
        public string Contamination { get; set; }

        [StringLength(30)]
        public string Slubs { get; set; }

        [StringLength(30)]
        public string LongThin { get; set; }

        [StringLength(30)]
        public string LongThick { get; set; }

        [StringLength(30)]
        public string DeadCottonLevel { get; set; }

        [StringLength(100)]
        public string Other { get; set; }

        [StringLength(1)]
        public string isSampleSentBuyer { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SampleSentBuyer { get; set; }

        public DateTime? SampleSentBuyerDate { get; set; }

        [StringLength(1)]
        public string isSampleSentSeller { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SampleSentSeller { get; set; }

        public DateTime? SampleSentSellerDate { get; set; }

        [StringLength(1)]
        public string isSampleoffice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SampleOffice { get; set; }

        public DateTime? SampleOfficeDate { get; set; }
    }
}
