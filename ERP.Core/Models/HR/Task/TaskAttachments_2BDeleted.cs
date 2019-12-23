using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR.Task
{
    public class TaskAttachments_2BDeleted
    {
        
        [Key]
        public int Id { get; set; }
                
        [StringLength(9)]
        public string TaskIDKey { get; set; }
                       
        [StringLength(250)]
        public string FileName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

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
