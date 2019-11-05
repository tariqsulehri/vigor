using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.HrIRepository
{
    public interface IHR_DesignationRepository
    {
        void Add(HR_Designation HR_Designation);
        void Edit(HR_Designation HR_Designation);
        bool IsDuplicate(HR_Designation HR_Designation);
        bool Remove(string id);
        HR_Designation FindById(string id);
        IEnumerable<HR_Designation> GetAllHR_Designation();
    }
}
