using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Common;
using ERP.Core.Models.HR;
using ERP.Core.Models.Parties;

namespace ERP.Core.Models.Finance
{
    public class FinVoucherDetail
    {
        [Key]
        public int Id { get; set;}

        [ForeignKey("FinVoucher")]
        [Required(ErrorMessage = "Please Define Voucher Key...")]
        [MaxLength(20)]
        public string VKey { get; set; }

        public virtual FinVoucher FinVoucher { get; set; }

        [ForeignKey("CoaL5")]
        [Required(ErrorMessage = "Please Define Voucher Key...")]
        [MaxLength(18)]
        public string GlCode { get; set; }
        public virtual CoaL5 CoaL5 { get; set;}
        
        [Required(ErrorMessage = "Please Define Voucher Date...")]
        public string Detail { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ChequeDate { get; set;}


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ClearingDate { get; set; }

        public decimal Debit { get; set;}
        public decimal Credit { get; set; }
        
        [MaxLength(25)]
        public string ChequeNo { get; set; }

       // [ForeignKey("HrDepartment")]
        public int DeptId { get; set;}
       // public virtual HrDepartment HrDepartment { get; set;}

       // [ForeignKey("HrEmployee")]
        public int EmpId { get; set; }
      //  public virtual HrEmployee HrEmployee { get; set; }

        //[ForeignKey("City")]
        public int LocId { get; set; }
       // public virtual City City { get; set; }
        public int CustomerId { get; set; }

    }
}
