using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.Models.HR.ViewModels
{
   public class MonthAttendance_VM
    {
        public string Forthemonth { get; set; }

        public string Fortheyear { get; set; }
        public int DayNumber { get; set; }

        public string EmployeeAttendanceId { get; set; }

        public string EmployeeFirstName { get; set; }

        public string EmployeeDepartmentName { get; set; }
        public string EmployeeDesignation { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ValidDateStart { get; set; }
        public string status { get; set; }
    }
}
