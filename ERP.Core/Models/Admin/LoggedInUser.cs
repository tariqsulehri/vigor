using ERP.Core.Models.Common;
using ERP.Core.Models.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.Admin
{
    public static class LoggedinUser
    {

        public static FinFescalYear CurrentFiscalYear;
        public static User LoggedInUser;
        public static Company Company;
        static LoggedinUser()
        {
            CurrentFiscalYear = new FinFescalYear();
            LoggedInUser = new User();
            Company = new Company();
        }

    }
}
