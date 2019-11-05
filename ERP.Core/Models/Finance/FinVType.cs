using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Core.Models.Finance
{
    public class FinVType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Define Voucher type description...")]
        [MaxLength(30)]
        public string Vtype { get; set; }

        [Required(ErrorMessage = "Please Define Description of...")]
        [MaxLength(50)]
        public string Description{ get; set; }

        [Required(ErrorMessage = "Voucher is Required or Must be Unique Key...eg(CPV, BPV.. )")]
        [MaxLength(3)]
        [Index(IsUnique = true)]
        public string Key { get; set; }

    }
}
