using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.HrIRepository
{
    public interface IHR_DayStatusRepository
    {
        void Add(HR_DayStatus HR_DayStatus);
        void Edit(HR_DayStatus HR_DayStatus);
        bool IsDuplicate(HR_DayStatus HR_DayStatus);
        bool Remove(string id);
        HR_DayStatus FindById(string id);
        IEnumerable<HR_DayStatus> GetAllHR_DayStatus();

    }
}
