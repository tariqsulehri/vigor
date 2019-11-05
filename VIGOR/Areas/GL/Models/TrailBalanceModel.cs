using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VIGOR.Areas.GL.Models
{
    public class TrailBalanceModel
    {
        public string LevelOfAccount { get; set; }
        public string ParentAccount { get; set; }
        public string AccountCode { get; set; }
        public string AccountTitle { get; set; }
        public decimal OPBAL { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal Balancee { get; set; }
        public int LEVEL { get; set; }
    }
}