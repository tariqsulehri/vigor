using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.HrIRepository
{
    public interface IHR_EmployeeTypeRepository
    {
        void Add(HR_EmployeeType HR_EmployeeType);
        void Edit(HR_EmployeeType HR_EmployeeType);
        bool IsDuplicate(HR_EmployeeType HR_EmployeeType);
        bool Remove(string id);
        HR_EmployeeType FindById(string id);
        IEnumerable<HR_EmployeeType> GetAllHR_EmployeeType();

    }
}
