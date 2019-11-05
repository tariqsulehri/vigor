using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.HrIRepository
{
    public interface IHR_EmployeeQualificationRepository
    {
        void Add(HR_EmployeeQualification HR_EmployeeQualification);
        void Edit(HR_EmployeeQualification HR_EmployeeQualification);
        bool IsDuplicate(HR_EmployeeQualification HR_EmployeeQualification);
        bool Remove(string id);
        HR_EmployeeQualification FindById(string id);
        IEnumerable<HR_EmployeeQualification> GetAllHR_EmployeeQualification();
    }

}

