using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Core.Models.Finance
{
    public class CoaL4
    {
        #region Class Property Declarations 

		 	  public CoaL4()
        {
            this.CoaL5 = new HashSet<CoaL5>();
           
        }
        [Key]
        [StringLength(13, MinimumLength = 13)]
        public string L4Code { get; set; }

        [Required(ErrorMessage = "You must enter title of particular account....")]
        [MaxLength(80)]
        public string Title { get; set; }
        public Boolean Active { get; set; }

        [Required(ErrorMessage = "You must enter title of particular account....")]
        [StringLength(9, MinimumLength = 9)]

        [ForeignKey("CoaL3")]
        public string L3Code { get; set; }
        public virtual CoaL3 CoaL3 { get; set; }
        public virtual ICollection<CoaL5> CoaL5 { get; set; }

        #endregion Class Property Declarations
    }
}
