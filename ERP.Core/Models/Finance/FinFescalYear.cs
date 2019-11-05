using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Finance
{
    public class FinFescalYear
    {

				 public FinFescalYear()
        {
            this.FinFescalYearDetails= new HashSet<FinFescalYearDetail>();
        }														  
        [Key]
        public int Id { get; set; }
	
        [Required(ErrorMessage = "Please Define Year Title ...")]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Fescal Year Key Should be Unqiue ...")]
        [MaxLength(14)]
        public string YearKey { get; set; }



        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public Boolean Active { get; set; }
        public virtual ICollection<FinFescalYearDetail> FinFescalYearDetails { get; set;}
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
