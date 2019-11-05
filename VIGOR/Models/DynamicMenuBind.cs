using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VIGOR.Models
{
    public class DynamicMenuBind
    {
        public int AdminMenuId { get; set; }
        public int UserId { get; set; }
        public string ModuleName { get; set; }
        public string Key { get; set; }
        public string Url { get; set; }
        public string DisplayName { get; set; }
        public string AdminMenuPermission { get; set; }
    }
}