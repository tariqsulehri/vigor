using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Admin
{
    public class AdminModules
    {
		  public AdminModules()
        {
            this.AdminModuleDetails = new HashSet<AdminModuleDetails>();
            this.UserModules = new HashSet<UserModules>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(50)]
        public string ModuleName { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(50)]
        public string Key     { get; set;}

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(100)]
        public string Url { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(50)]
        public string DisplayName { get; set; }
        public bool IsActive { get; set;}
        public virtual ICollection<AdminModuleDetails> AdminModuleDetails { get; set; }
        public virtual ICollection<UserModules> UserModules { get; set; }

    }
}
