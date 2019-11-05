namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SS_CommissionInvoice
    {
        [Key]
        [StringLength(10)]
        public string CommissionInvoiceNo { get; set; }

        [Required]
        [StringLength(10)]
        public string SalesContractNo { get; set; }

        [Required]
        [StringLength(3)]
        public string Company { get; set; }

        public DateTime InvoiceDate { get; set; }

        [StringLength(13)]
        public string ShipmentScheduleShipmentNo { get; set; }

        [StringLength(250)]
        public string SupplierInvoiceNo { get; set; }

        public DateTime? SupplierInvoiceDate { get; set; }

        [Required]
        [StringLength(3)]
        public string Currency { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ExchangeRate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal InvoiceTotal { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? InvoiceDiscount { get; set; }

        [Required]
        [StringLength(200)]
        public string Signature { get; set; }

        public bool IsPosted { get; set; }

        public bool? IncludeSalesTax { get; set; }

        public bool? WithHeldSalesTax { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SalestaxRate { get; set; }

        [StringLength(2)]
        public string SalesTaxOffice { get; set; }

        [Required]
        [StringLength(4)]
        public string UserId_as_CreatedBy { get; set; }

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
