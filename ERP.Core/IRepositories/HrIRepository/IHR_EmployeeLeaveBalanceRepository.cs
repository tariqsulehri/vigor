using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.HrIRepository
{
    public interface IHR_EmployeeLeaveBalanceRepository
    {
        void Add(HR_EmployeeLeaveBalance HR_EmployeeLeaveBalance);
        void Edit(HR_EmployeeLeaveBalance HR_EmployeeLeaveBalance);
        bool IsDuplicate(HR_EmployeeLeaveBalance HR_EmployeeLeaveBalance);
        bool Remove(string id);
        HR_EmployeeLeaveBalance FindById(string id);
        IEnumerable<HR_EmployeeLeaveBalance> GetAllHR_EmployeeLeaveBalance();
    }
}
