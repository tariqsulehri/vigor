using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Finance
{
    public class FinVoucher
    {
		  public FinVoucher(){this.FinVoucherDetail = new HashSet<FinVoucherDetail>();}
      																		  
        [Key]
        [Required(ErrorMessage = "Please Define Voucher Key...")]
        [MaxLength(20)]
        public string VKey { get; set; }
        public int VoucherNo { get; set; }
        public Boolean PostFlag { get; set;}

        [Required(ErrorMessage = "Please Define Voucher Key...")]
        [MaxLength(10)]
        public string FescalMonth { get; set;}
        
        [Required(ErrorMessage = "Please Define Voucher type...")]
        [MaxLength(3)]
        public string Vtype { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime VoucherDate { get; set; }

        [DataType("decimal(12,2")]
        public decimal TotalDebit { get; set;}

        [DataType("decimal(12,2")]
        public decimal TotalCredit { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please Define Account ...")]
        [MaxLength(18)]
        public string AccountCode { get; set; }
					  [NotMapped]									
        [Required(ErrorMessage = "Please Define Voucher Detail...")]
        public string dtDetail { get; set; }
        
        public string CheqNo { get; set; }

        [Required(ErrorMessage =  "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime PostedDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ModifiedOn { get; set; }

        public string Detail { get; set; }
        public Boolean IsPosted { get; set; }
        public Boolean IsEdited { get; set; }
        public Boolean IsVerified { get; set; }

        [Required(ErrorMessage = "User Id is Required...")]
        public int CreateUserId { get; set; }
        public int PostedUserId { get; set; }
        public int VerifyUserId { get; set; }
        public int ModifiedBy { get; set; }
        public virtual ICollection<FinVoucherDetail> FinVoucherDetail { get; set; }

    }
}
