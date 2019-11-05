using ERP.Core.Models.HR.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.HrIRepository.TaskRepository
{
    public interface IHrTaskProgressRepository
    {
        void Add(HrTaskProgress hrTaskProgress);
        void Edit(HrTaskProgress hrTaskProgress);
        bool Remove(HrTaskProgress hrTaskProgress);
        HrTaskProgress FindById(int id);
        IEnumerable<HrTaskProgress> GetAllHrTaskProgress();
    }
}
