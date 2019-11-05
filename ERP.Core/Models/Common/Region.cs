using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Core.Models.Common
{
    public class Region
    {
        [Key]
        public int Id { get; set; }

        [StringLength(4)]
        public string RefId { get; set; }

        [Required(ErrorMessage = "Region name is required field..")]
        [StringLength(30)]
        public string Title { get; set; }
        public ICollection<Country> Countries { get; set;}
      
    }
}
