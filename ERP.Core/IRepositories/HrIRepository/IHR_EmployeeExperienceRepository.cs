using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.HrIRepository
{
    public interface IHR_EmployeeExperienceRepository
    {

        void Add(HR_EmployeeExperience HR_EmployeeExperience);
        void Edit(HR_EmployeeExperience HR_EmployeeExperience);
        bool IsDuplicate(HR_EmployeeExperience HR_EmployeeExperience);
        bool Remove(string id);
        HR_EmployeeExperience FindById(string id);
        IEnumerable<HR_EmployeeExperience> GetAllHR_EmployeeExperience();


    }
}
