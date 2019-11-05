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
    public interface IHR_HistoryRepository
    {
        void Add(HR_History HR_History);
        void Edit(HR_History HR_History);
        bool IsDuplicate(HR_History HR_History);
        bool Remove(string id);
        HR_History FindById(string id);
        IEnumerable<HR_History> GetAllHR_History();

    }
}
