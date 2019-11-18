using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class IndentAgent
    {

        public int Id { get; set; }

        
        public int IndentId { get; set; }
        
        [StringLength(10)]
        public string SalesContractNo { get; set; }

        public int CustomerIDasAgentID { get; set; }
        
        [StringLength(6)]
        public string CustomerIDasAgentCodeRef { get; set; }

        [StringLength(1)]
        public string AgentStatus { get; set; }
    }
}
