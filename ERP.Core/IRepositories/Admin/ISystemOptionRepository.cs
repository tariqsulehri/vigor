using ERP.Core.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Core.IRepositories.Admin
{
    public interface ISystemOptionRepository
    {
        void Add(SystemOption systemOption);
        void Edit(SystemOption systemOption);
        bool Remove(SystemOption systemOption);
        SystemOption FindById(int id);
        bool IsDuplicate(SystemOption systemOption);
        IEnumerable<SystemOption> GetAllSystemOptions();
        IEnumerable<SystemOption> GetAllSystemOptionsByUser(int userId);
    }
}
