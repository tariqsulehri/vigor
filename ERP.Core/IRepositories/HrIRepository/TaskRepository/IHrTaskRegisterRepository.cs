using ERP.Core.Models.HR.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.HrIRepository.TaskRepository
{
    public interface IHrTaskRegisterRepository
    {
        void Add(HrTaskRegister hrTaskRegister);
        void Edit(HrTaskRegister hrTaskRegister);
        bool Remove(HrTaskRegister hrTaskRegister);
        HrTaskRegister FindById(int id);
        IEnumerable<HrTaskRegister> GetAllHrTaskRegister();
    }
}
