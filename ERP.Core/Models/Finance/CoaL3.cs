using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Core.Models.Finance
{
    public class CoaL3
    {
        #region Class Property Declarations 

		   public CoaL3()
        {
            this.CoaL4 = new HashSet<CoaL4>();
           
        }
        [Key]
        [StringLength(9, MinimumLength = 9)]
        public string L3Code { get; set; }

        [Required(ErrorMessage = "You must enter title of particular account....")]
        [MaxLength(70)]
        public string Title { get; set; }
        public Boolean Active { get; set; }

        [Required(ErrorMessage = "You must enter title of particular account....")]
        [StringLength(5, MinimumLength = 5)]

        [ForeignKey("CoaL2")]
        public string L2Code { get; set; }
        public virtual CoaL2 CoaL2 { get; set; }
        public  virtual ICollection<CoaL4> CoaL4 { get; set; }

        #endregion Class Property Declarations
    }
}
