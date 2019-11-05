using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.HrIRepository
{
    public interface IHR_EmployeeLoanAdvanceBalanceRepository
    {
        void Add(HR_EmployeeLoanAdvanceBalance HR_EmployeeLoanAdvanceBalance);
        void Edit(HR_EmployeeLoanAdvanceBalance HR_EmployeeLoanAdvanceBalance);
        bool IsDuplicate(HR_EmployeeLoanAdvanceBalance HR_EmployeeLoanAdvanceBalance);
        bool Remove(string id);
        HR_EmployeeLoanAdvanceBalance FindById(string id);
        IEnumerable<HR_EmployeeLoanAdvanceBalance> GetAllHR_EmployeeLoanAdvanceBalance();

    }
}
