using ERP.Core.Models.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.HrIRepository
{
    public interface IHR_HistoryDetailsRepository
    {
        void Add(HR_HistoryDetails HR_HistoryDetails);
        void Edit(HR_HistoryDetails HR_HistoryDetails);
        bool IsDuplicate(HR_HistoryDetails HR_HistoryDetails);
        bool Remove(string id);
        HR_HistoryDetails FindById(string id);
        IEnumerable<HR_HistoryDetails> GetAllHR_HistoryDetails();
    }
}
