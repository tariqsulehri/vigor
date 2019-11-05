using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Common
{
    public class State
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "State name is required field...")]
        [StringLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "State code is required field...")]
        [StringLength(6), MinLength(6)]
        public string Stcode { get; set; }

        [Required(ErrorMessage = "State Id is required field..")]
        [ForeignKey("Country")]
        public int CId { get; set; }
        public virtual Country Country { get; set; }
        private ICollection<City> Cities { get; set; }

    }
}
