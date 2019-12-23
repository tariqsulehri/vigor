using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Core.Models.Common;
using ERP.Core.Models.Finance;
using ERP.Core.Models.Indenting.IndentDomestic;
using ERP.Core.Models.Parties;
using ERP.Core.Models.Indenting.Inspection;
using ERP.Core.Models.Indenting.IndentExport;

namespace ERP.Core.Models.Party
{
    public class FinParty
    {
        #region Class Property Declarations 

        public FinParty()
        {
            this.CustomerBrands = new HashSet<CustomerBrand>();
            this.FinVoucherDetails = new HashSet<FinVoucherDetail>();
            this.CustomerCertifications = new HashSet<CustomerCertification>();
            this.CustomerContactType = new HashSet<CustomerContact>();
            this.CustomerMachineses = new HashSet<CustomerMachine>();
            this.CustomerSpecialInstructions = new HashSet<CustomerInstruction>();
            this.CustomerSocials = new HashSet<CustomerSocial>();
            this.CustomerContactPerson = new HashSet<CustomerContactPerson>();
            this.CustomerUnits = new HashSet<CustomerUnit>();
            this.FNLAccounts = new HashSet<FNLAccount>();

        }


        [Key]
        public int Id { get; set; }

        [StringLength(6)]
        public string RefId { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(50)]
        public string Title { get; set; }
        [NotMapped]
        public Boolean IsGlCustomer { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(100)]


        public string CompanyName { get; set; }

        [MaxLength(30)]
        public string Phone { get; set; }

        [MaxLength(30)]

        public string Fax { get; set; }

        [MaxLength(30)]

        public string MailingAddress { get; set; }
        [MaxLength(100)]
        public string DispatchAddress { get; set; }

        [MaxLength(50)]

        public string EmailAddress { get; set; }

        [MaxLength(100)]

        public string WebPage { get; set; }

        [MaxLength(50)]

        public string NtnNo { get; set; }

        [MaxLength(50)]

        public string GstNo { get; set; }
        public Boolean Active { get; set; }
        public Boolean IsSeller { get; set; }
        public Boolean IsBuyer { get; set; }
        public Boolean IsAgent { get; set; }
        public Boolean IsCust { get; set; }
        public Boolean IsDomestic { get; set; }
        public Boolean IsInternational { get; set; }

        //[Required(ErrorMessage = "This is Required field....")]
        //[ForeignKey("Country")]
        public int CountryCode { get; set; }
        //public virtual Country Country { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [ForeignKey("City")]
        public int CityCode { get; set; }
        public virtual City City { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [StringLength(18, MinimumLength = 18)]
        [ForeignKey("CoaL5")]
        public string GlCode { get; set; }
        public virtual CoaL5 CoaL5 { get; set; }


        public virtual ICollection<FinVoucherDetail> FinVoucherDetails { get; set; }
        public virtual ICollection<CustomerCertification> CustomerCertifications { get; set; }
        public virtual ICollection<CustomerContact> CustomerContactType { get; set; }
        public virtual ICollection<CustomerMachine> CustomerMachineses { get; set; }
        public virtual ICollection<CustomerInstruction> CustomerSpecialInstructions { get; set; }
        public virtual ICollection<CustomerSocial> CustomerSocials { get; set; }
        public virtual ICollection<CustomerBrand> CustomerBrands { get; set; }
        public virtual ICollection<CustomerContactPerson> CustomerContactPerson { get; set; }
        public virtual ICollection<CustomerUnit> CustomerUnits { get; set; }
        public virtual ICollection<FNLAccount> FNLAccounts { get; set;}

        public ICollection<IndDomesticInquiry> IndDomesticInquiries { get; set; }
        public ICollection<IndExportInquiry> IndExportInquiry { get; set; }
        public ICollection<IndDomestic> IndDomestic { get; set; }

        //public ICollection<IndDomesticDetail> IndDomesticDetail { get; set; }
  //    public ICollection<FabricInspReportLocal> FabricInspReportLocal { get; set; }
        public ICollection<IndCommissionInvoiceDetail> IndCommissionInvoiceDetail { get; set; }
//        public virtual ICollection<YarnInspection> YarnInspections { get; set; }
        public virtual ICollection<FabricSample> FabricSample { get; set; }
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
