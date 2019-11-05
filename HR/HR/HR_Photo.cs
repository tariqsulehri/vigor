using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR
{
    public class HR_Photo
    {
        public int id { get; set; }

        [StringLength(5)]
        public string EmployeeNo { get; set; }

        [StringLength(200)]
        public string filePatch {get; set;}
    }
}
