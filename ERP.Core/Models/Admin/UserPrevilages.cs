using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Admin
{
    public class UserPrevilage
    {
        [Key]
        public int UserPrevilageId { get; set; }
        public string mKey { get; set;}
        public int UserId { get; set; }
        public int OptionId { get; set; }
        public bool Allowed { get; set; }
    }
}
