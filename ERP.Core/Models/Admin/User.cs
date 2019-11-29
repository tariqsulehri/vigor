using ERP.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Admin
{
    public class User
    {
        public User()
        {
            UserModules = new HashSet<UserModules>();
            UserModuleDetails = new HashSet<UserModuleDetails>();
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(50)]
        public string UserName { get; set; }

        [StringLength(4)]
        public string RefId { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(60)]
        public string Email { get; set; }

        //[Required(ErrorMessage = "This is Required field....")]
        [MaxLength(100)]
        public string Password { get; set; }

        //[Required(ErrorMessage = "This is Required field....")]
        [MaxLength(25)]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "This is Required field....")]
        [MaxLength(25)]
        public string LastName { get; set; }

        //[Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public int EmployeeId { get; set; }
        public Gender Gender { get; set; }

        [MaxLength(20)]
        public string ContactNumber { get; set; }
        public Boolean ChangePasswordWhenLogon { get; set; }
        public Boolean PasswordNeverExpire { get; set; }
        public Boolean IncludedCEOInEmail { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ExpiresOn { get; set; }
        public Boolean IsAdmin { get; set; }
        public Boolean IsManagmentRepresentative { get; set; }
        public UserStatus Status { get; set; }
        public Boolean IsActive { get; set; }
        public virtual ICollection<UserModules> UserModules { get; set; }
        public virtual ICollection<UserModuleDetails> UserModuleDetails { get; set; }
        public virtual ICollection<AdminUserDealsInDepartment> AdminUserDealsInDepartments { get; set; }

        public int CreatedBy { get; set; } 

        [Required(ErrorMessage = "Field is required....")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; } = DateTime.Now; 
        public int ModifiedBy { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ModifiedOn { get; set; } = DateTime.Now;

    }
}
