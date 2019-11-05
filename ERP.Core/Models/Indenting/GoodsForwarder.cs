using ERP.Core.Models.Indenting.IndentDomestic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Core.Models.Indenting
{
    public class GoodsForwarder
    {
        public int Id { get; set; }

        [StringLength(4)]
        public string RefId { get; set; }

        [Required(ErrorMessage = "This is Required field....")]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }

        public ICollection<IndDomesticDispatchSchedule> IndDomesticDisplatchSchedule { get; set; }

        public int  CreatedBy { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
        public int   ModifiedBy { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ModifiedOn { get; set; }
    }
}
