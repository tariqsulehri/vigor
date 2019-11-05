namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_DELCommissionInvoice
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string CommissionInvoiceNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string SalesContractNo { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(3)]
        public string Company { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime InvoiceDate { get; set; }

        [StringLength(13)]
        public string ShipmentScheduleShipmentNo { get; set; }

        [StringLength(250)]
        public string SupplierInvoiceNo { get; set; }

        public DateTime? SupplierInvoiceDate { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(3)]
        public string Currency { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "numeric")]
        public decimal ExchangeRate { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "numeric")]
        public decimal InvoiceTotal { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? InvoiceDiscount { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(200)]
        public string Signature { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool IsPosted { get; set; }

        public bool? IncludeSalesTax { get; set; }

        public bool? WithHeldSalesTax { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SalestaxRate { get; set; }

        [StringLength(2)]
        public string SalesTaxOffice { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(4)]
        public string UserId_as_CreatedBy { get; set; }

        [Key]
        [Column(Order = 10)]
        public DateTime CreatedOn { get; set; }

        [StringLength(4)]
        public string UserId_as_ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        [StringLength(4)]
        public string UserId_as_PostedBy { get; set; }

        public DateTime? PostedOn { get; set; }

        public DateTime? DispatchesIncludeFrom { get; set; }

        public DateTime? DispatchesIncludeTo { get; set; }
    }
}
