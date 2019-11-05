using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Admin
{
    public class UserModuleDetails
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "This is Required field....")]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        //[Required(ErrorMessage = "This is Required field....")]
        //[ForeignKey("UserModules")]
        //public int ModulelId { get; set; }
        //public virtual UserModules UserModules { get; set; }
		  [Required(ErrorMessage = "This is Required field....")]
        [ForeignKey("AdminModuleDetails")]
        public int ModuleDtlId { get; set; }
        public virtual AdminModuleDetails AdminModuleDetails { get; set; }
       									
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
