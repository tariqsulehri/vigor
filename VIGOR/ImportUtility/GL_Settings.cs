namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GL_Settings
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(3)]
        public string CompanyID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(1)]
        public string PostToGeneralLedger { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1)]
        public string PostThroughGeneralLedger { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(1)]
        public string IsVoucherReqAuthorise { get; set; }

        [StringLength(250)]
        public string VoucherAuthorizationCode { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(1)]
        public string IsFinancislCreated { get; set; }

        public int? StartingFiscalMonth { get; set; }

        public int? StartingFiscalYear { get; set; }

        public int? StartingDataEntryMonth { get; set; }

        [StringLength(3)]
        public string LocalContractsDefCurrency { get; set; }

        [StringLength(3)]
        public string ExportContractsDefCurrency { get; set; }

        [StringLength(6)]
        public string CompanyInCustomers { get; set; }
    }
}
