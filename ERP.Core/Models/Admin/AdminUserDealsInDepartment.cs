using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Admin
{
    public class AdminUserDealsInDepartment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [MaxLength(6)]
        public string mKey { get; set;}

        [ForeignKey("user")]
        public int UserId { get; set; }
        public virtual User user { get; set; }

        [ForeignKey("HrDepartment")]
        public int DeptId { get; set; }
        public virtual HrDepartment HrDepartment { get; set; }






    }
}
