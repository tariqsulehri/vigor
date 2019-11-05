using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Common;															  
using ERP.Core.Models.Party;				  											 
using ERP.Core.Models.Common.Party;

namespace ERP.Core.Models.Parties
{
    public class CustomerCertification
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [ForeignKey("FinParty")]
        public int PartyId { get; set; }
        public virtual FinParty FinParty { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [ForeignKey("Certification")]

        public int CertifyId { get; set; }
        public virtual Certifications Certification { get; set; }
        
        public bool IsActive { get; set;}
          
        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime IssuedOn { get; set; }

        [Required(ErrorMessage = "Field is required....")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ValidTill { get; set; }

    }
}