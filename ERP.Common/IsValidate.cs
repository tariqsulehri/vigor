using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.Core.Models.Admin;

namespace ERP.Common
{
    public static class IsValidate
    {
        public static Boolean IsvalidateYear(DateTime dateFrom, DateTime dateTo)
        {
            var sDate = LoggedinUser.CurrentFiscalYear.StartDate;
            var eDate = LoggedinUser.CurrentFiscalYear.EndDate;
            if (dateFrom >= sDate && dateFrom <= eDate && dateFrom <= dateTo && dateTo <= eDate && dateTo >= sDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
