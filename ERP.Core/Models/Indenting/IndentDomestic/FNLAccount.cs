using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    using ERP.Core.Models.Party;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class FNLAccount
    {
        [Key]
        [StringLength(10, MinimumLength = 10)]
        public string FNLAccountID { get; set; }

        [StringLength(18, MinimumLength = 18)]
        public string PartyAccount { get; set; }

        [StringLength(18, MinimumLength = 18)]
        public string DebtorAccount { get; set; }

        [ForeignKey("FinParty")]
        public int PartyId { get; set; }
        public virtual FinParty FinParty { get; set; }


        [StringLength(6)]
        public string FNLAccountIDRef { get; set; }

        [StringLength(6)]
        public string PartyAccountRef { get; set; }

        [StringLength(6)]
        public string DebtorAccountRef { get; set; }

        public int CurrencyID { get; set; }

        public bool? Returnable { get; set; }

        public int ReturnableCurrency { get; set; }

        public int CompanyID { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? InActiveSince { get; set; }

        public decimal? LinkedAccount { get; set; }


        public int CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? CreatedOn { get; set; }
        public int ModifiedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? ModifiedOn { get; set; }

    }


}
