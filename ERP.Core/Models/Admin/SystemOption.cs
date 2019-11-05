using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Admin
{
    public class SystemOption
    {
        [Key]
        public int OptionId { get; set; }

        [Required, MaxLength(150)]
        public string OptionDescription { get; set; }
        public int OptionLevel { get; set; }
        public int? ParentID { get; set; }
        [StringLength(2)]
        public string IsMenuOption { get; set; }
        public bool Allowed { get; set; }
        [StringLength(50)]
        public string FormObject { get; set; }
        [StringLength(2)]
        public string IsFunction { get; set; }
        [ForeignKey("ParentID")]
        public virtual SystemOption Parent { get; set; }
        public virtual ICollection<SystemOption> Childs { get; set; }
    }
}
