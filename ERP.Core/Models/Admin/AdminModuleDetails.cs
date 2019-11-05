using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Admin
{
    public class AdminModuleDetails
    {
		  public AdminModuleDetails()
        {
            this.UserModuleDetails = new HashSet<UserModuleDetails>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(50)]
        public string ModuleName { get; set; }

        
        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(50)]
        public string Key { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(100)]
        public string Url { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(50)]
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [ForeignKey("AdminModules")]
        public int AModuleId { get; set; } 
        public virtual AdminModules AdminModules { get; set;}
        public virtual ICollection<UserModuleDetails> UserModuleDetails { get; set;}
    }
}
