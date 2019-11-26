using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Common
{
    public static class ConfigSettings
    {
        public static String ConnectionString = ConfigurationManager.ConnectionStrings["ErpDbContext"].ConnectionString;
    }
}
