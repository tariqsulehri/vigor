namespace VIGOR.ImportUtility
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Store_VoucherDetails
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(15)]
        public string DocumentID { get; set; }

        [StringLength(14)]
        public string PODetailID { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        public decimal StoreItemID { get; set; }

        [StringLength(3)]
        public string PurchaseUnit { get; set; }

        [StringLength(3)]
        public string IssueUnit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PurchaseQuantity { get; set; }

        [StringLength(25)]
        public string Brand { get; set; }

        [StringLength(4)]
        public string UnitConvertID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ConvertedQuantity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IssuedQuantity { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Rate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Amount { get; set; }

        [StringLength(3)]
        public string CompanyID { get; set; }

        public DateTime? DocDate { get; set; }

        [StringLength(1)]
        public string Isposted { get; set; }

        public virtual Store_Voucher Store_Voucher { get; set; }
    }
}
