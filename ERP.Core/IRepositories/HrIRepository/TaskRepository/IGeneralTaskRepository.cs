using ERP.Core.Models.HR.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.HrIRepository.TaskRepository
{
    public interface IGeneralTaskRepository
    {
        void Add(GeneralTask GeneralTask);
        void Edit(GeneralTask GeneralTask);
        bool Remove(GeneralTask GeneralTask);
        HrTaskProgress FindById(int id);
        IEnumerable<GeneralTask> GetAllGeneralTask();
    }
}
