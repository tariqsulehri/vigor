using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.HrIRepository
{
    public interface IHR_EmployeeAllowancesRepository
    {
        void Add(HR_EmployeeAllowances HR_EmployeeAllowances);
        void Edit(HR_EmployeeAllowances HR_EmployeeAllowances);
        bool IsDuplicate(HR_EmployeeAllowances HR_EmployeeAllowances);
        bool Remove(string id);
        HR_EmployeeAllowances FindById(string id);
        IEnumerable<HR_EmployeeAllowances> GetAllHR_EmployeeAllowances();

    }
}
