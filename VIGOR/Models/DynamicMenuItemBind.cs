using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VIGOR.Models
{
    public class DynamicMenuItemBind
    {
        public int? UserId { get; set; }
        public int AdminMenuId { get; set; }
        public int AdminMenuDetailId { get; set; }
        public string ModuleDtlName { get; set; }
        public string ModuleDtlDisplayName { get; set; }
        public string ModuleDtlKey { get; set; }
        public string ModuleDtlUrl { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}