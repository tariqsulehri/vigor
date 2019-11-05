using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Inventory
{
    public class Brand
    {
        #region Class Property Declarations 

        [Key]
        public int Id {get; set; }

        [Required(ErrorMessage = "You must enter title of particular account....")]
        [MaxLength(30)]
        [Index("IX_Brand_Inventory", IsUnique = true)]
        public string Title { get; set; }

        [StringLength(4)]
        public string RefId { get; set; }
        public Boolean Active { get; set; }


        [Required(ErrorMessage = "User Id is required filed ....")]
        public string UserId { get; set; }

        #endregion Class Property Declarations
    }
}

