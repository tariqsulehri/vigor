using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Core.Models.Common;
using ERP.Core.Models.Parties;
using ERP.Core.Models.Party;

namespace ERP.Core.Models.Finance
{
    public class CoaL5
    {
        #region Class Property Declarations 

        [Key]
        [StringLength(18, MinimumLength = 18)]
        public string L5Code { get; set; }

        [Required(ErrorMessage = "You must enter title of particular account....")]
        [MaxLength(50)]
        public string Title { get; set; }
		[MaxLength(1)]
        public string BookType { get; set; }		
        public Boolean Active { get; set; }
        public Boolean IsDept { get; set; }
        public Boolean IsLoc { get; set; }
        public Boolean IsEmp { get; set; }
        public Boolean IsCust { get; set; }

        public virtual ICollection<FinParty> FinParties { get; set;}
        public virtual ICollection<FinBudget> FinBudject { get; set; }
        public virtual ICollection<FinLedger> FinLedger { get; set; }

        [Required(ErrorMessage = "You must enter title of particular account....")]
        [StringLength(13, MinimumLength = 13)]
        [ForeignKey("CoaL4")]
        public string L4Code { get; set; }
        public virtual CoaL4 CoaL4 { get; set; }

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

        #endregion Class Property Declarations
    }
}
