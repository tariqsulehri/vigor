﻿using ERP.Core.Models.Admin;
using ERP.Core.Models.HR.Task;
using ERP.Core.Models.Indenting;
using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Core.Models.Indenting.IndentExport;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR
{
    public class HrDepartment
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        //===========================================================
        [StringLength(4)]
        public string RefId { get; set; }

        [NotMapped]
        public bool IsAllow { get; set; }

        [StringLength(50)]
        public string DeptDescription { get; set; }

        [StringLength(50)]
        public string DeptHead { get; set; }

        [StringLength(100)]
        public string DeptEmailAddress { get; set; }

        [StringLength(1)]
        public string isActve { get; set; }

        [StringLength(1)]
        public string DeptNature { get; set; }

        [StringLength(1)]
        public string MarketNature { get; set; }

        [StringLength(1)]
        public string ScheduleType { get; set; }

        [StringLength(2)]
        public string ContractAbbreviation { get; set; }

        public DateTime? DeptCreatedOn { get; set; }

        [StringLength(3)]
        public string CompanyID { get; set; }

        public DateTime? DeptInActiveSince { get; set; }

        [StringLength(1)]
        public string RequireAllColumns { get; set; }

        public int? SalesCommissionAccount { get; set; }

        public decimal? FCSalesCommissionAccountRef { get; set; }
        public string FCSalesCommissionAccount { get; set; }


        public decimal? BadDebtAccountRef { get; set; }
        public string BadDebtAccount { get; set; }

        public decimal ClaimAccountRef { get; set; }
        public decimal ClaimAccount { get; set; }

        public bool ShowQtyinBVolume { get; set; }

        [StringLength(2)]
        public string StandardUnit { get; set; }

        public decimal? ValidShipmentDelayDays { get; set; }


        public virtual ICollection<HrEmployee> HrEmployees { get; set;}
        public virtual ICollection<IndDomesticInquiry> IndDomesticInquiries { get; set; }
        public virtual ICollection<IndExportInquiry> IndExportInquiry { get; set; }
        public virtual ICollection<DeptDealsInCommodityType> DeptDealsInCommodityType { get; set; }
        public virtual ICollection<DeptDealsInMarkeet> DeptDealsInMarkeet { get; set; }
        public virtual ICollection<HrTaskRegister> HrTaskRegister { get; set; }
        public virtual ICollection<AdminUserDealsInDepartment> AdminUserDealsInDepartments { get; set; }
        public virtual ICollection<HR_SalaryMaster> HR_SalaryMaster { get; set; }
        public virtual ICollection<GeneralTask> GeneralTask { get; set; }
        public virtual ICollection<MinutesOfMeeting> MinutesOfMeeting { get; set;}

        //================================================================
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
        
    }
}
