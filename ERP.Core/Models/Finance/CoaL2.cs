using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Core.Models.Finance
{
    public class CoaL2
    {
        #region Class Property Declarations 

		 public CoaL2()
        {
            this.CoaL3 = new HashSet<CoaL3>();
            
        } 
        [Key]
        [StringLength(5, MinimumLength = 5)]
        public string L2Code { get; set; }

        [Required(ErrorMessage = "You must enter title of particular account....")]
        [MaxLength(30)]
        public string Title { get; set; }
        public Boolean Active { get; set; }

        [Required(ErrorMessage = "You must enter title of particular account....")]
        [StringLength(2, MinimumLength = 2)]

        [ForeignKey("CoaL1")]
        public string L1Code { get; set; }
        public  virtual CoaL1 CoaL1 { get; set; }
        public virtual ICollection<CoaL3> CoaL3 { get; set;}

        #endregion Class Property Declarations
    }
}
