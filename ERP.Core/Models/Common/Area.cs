using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Common
{
    public class Area
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Area name is required field...")]
        [StringLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Area code is required field...")]
        

        [ForeignKey("City")]
        public int Ctcode { get; set; }
        public virtual City City { get; set; }

    }

    
}
