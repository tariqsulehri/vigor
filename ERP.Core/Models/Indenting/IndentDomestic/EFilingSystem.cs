using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.IndentDomestic
{
    public class EFilingSystem
    {
        [Key]
        [StringLength(10)]
        public string EFilingID { get; set; }

        [StringLength(2)]
        public string DocumentType { get; set; }

        public int TranType { get; set; }

        [StringLength(200)]
        public string FileDescription { get; set; }

        [StringLength(150)]
        public string FileAttached { get; set; }


        [Required]
        public int CompanyId { get; set; }

        [StringLength(3)]
        public string Company_Key { get; set; }

        [StringLength(20)]
        public string ReferenceID1 { get; set; }

        [StringLength(20)]
        public string ReferenceID2 { get; set; }

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
