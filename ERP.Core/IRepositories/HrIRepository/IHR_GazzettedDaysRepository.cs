using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.HrIRepository
{
    public interface IHR_GazzettedDaysRepository
    {
        void Add(HR_GazzettedDays HR_GazzettedDays);
        void Edit(HR_GazzettedDays HR_GazzettedDays);
        bool IsDuplicate(HR_GazzettedDays HR_GazzettedDays);
        bool Remove(string id);
        HR_GazzettedDays FindById(string id);
        IEnumerable<HR_GazzettedDays> GetAllHR_GazzettedDays();


    }
}
