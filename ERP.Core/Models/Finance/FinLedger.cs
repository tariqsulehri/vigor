using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Common;

namespace ERP.Core.Models.Finance
{
    public class FinLedger
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

        [ForeignKey("FinVoucher")]
        [Required(ErrorMessage = "Please Define Voucher Key...")]
        [MaxLength(20)]
        public string VKey { get; set; }
        public virtual FinVoucher FinVoucher { get; set; }

        [ForeignKey("CoaL5")]
        [Required(ErrorMessage = "Please Define Voucher Key...")]
        [MaxLength(18)]
        public string GlCode { get; set; }
        public virtual CoaL5 CoaL5 { get; set; }

        [Required(ErrorMessage = "Please Define Voucher Date...")]
        public string Detail { get; set; }

        public DateTime ChequeDate { get; set; }
        public DateTime ClearingDate { get; set; }

        [MaxLength(25)]
        public string ChequeNo { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
		public int DeptId { get; set; }
        public int EmpId { get; set; }
        public int LocId { get; set; }
        public int CustomerId { get; set; }								  
        public int UserId { get; set;}
    }
}
