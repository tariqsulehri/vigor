using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Indenting.viewModels
{
    public class CommodityBaseDepartments_VM
    {

        public int UserId { get; set; } 
        public int DeptId { get; set; }
        public string DepartmentName { get; set; }
        public int CommodityTypeId { get; set; }
        public  string CommodityTypeName { get; set; }
        public  int DealsInId { get; set; }
        public string MarkeetName { get; set; }

    }
}
