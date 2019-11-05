using System;
									using System.Collections.Generic;	  
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Core.Models.Finance
{
    public class CoaL1
    {
        #region Class Property Declarations 

		 	  public CoaL1()
        {
            this.CoaL2 = new HashSet<CoaL2>();
        }
        [Key]
        [StringLength(2, MinimumLength = 2)]
        public string L1Code { get; set; }

        [Required(ErrorMessage = "You must enter title of particular account....")]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required(ErrorMessage = "You must define account type ....")]
        [StringLength(2, MinimumLength = 2)]
        public string Type { get; set; }
        public Boolean Active { get; set; }


        [Required(ErrorMessage = "Company code must be required ....")]
        [StringLength(2, MinimumLength = 2)]
        public string Co { get; set; }
 public virtual ICollection<CoaL2> CoaL2 { get; set; }
   
        #endregion Class Property Declarations
    }
}
