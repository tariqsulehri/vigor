using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Admin
{
    public class UserModules
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        //[Required(ErrorMessage = "This is Required field....")]
        //[ForeignKey("AdminModules")]
        //public int ModuleId { get; set; }
        //public virtual AdminModules AdminModules { get; set; }
        // public virtual ICollection<UserModuleDetails> UserModuleDetails { get; set; }
		    [Required(ErrorMessage = "This is Required field....")]
        [ForeignKey("AdminModules")]
        public int ModuleId { get; set; }
        public virtual AdminModules AdminModules { get; set; }
		
        public int CreatedBy { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ModifiedOn { get; set; }

    }
}
