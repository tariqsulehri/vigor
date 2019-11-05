namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_IndentAgents
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string SalesContractNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string CustomerIDasAgentCode { get; set; }

        [StringLength(1)]
        public string AgentStatus { get; set; }
    }
}
