using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Finance;
using ERP.Core.Models.Parties;
using ERP.Core.Models.Party;
using ERP.Core.Models.HR;

namespace ERP.Core.Models.Common
{
    public class City
    {
        public int Id { get; set; }

        [StringLength(4)]
        public string RefId { get; set; }

        [Required(ErrorMessage = "City name is required field...")]
        [StringLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "City code is required field...")]
        public int Ccode { get; set; }

        [ForeignKey("State")]
        public int StId { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<Area> Area { get; set; }
        public virtual ICollection<FinParty> FinParties { get; set; }
        public virtual ICollection<FinVoucherDetail> FinVoucherDetails { get; set; }
//        public virtual ICollection<HrEmployee> HrEmaployees { get; set; }

    }


}
